using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Services.Interfaces;
using HajjSystem.Data;
using AutoMapper;

namespace HajjSystem.Services.Implementations;

public class ContractService : IContractService
{
    private readonly IContractRepository _repository;
    private readonly IVehicleContractService _vehicleContractService;
    private readonly ICompanyRepository _companyRepository;
    private readonly IVendorRepository _vendorRepository;
    private readonly HajjSystemContext _context;
    private readonly IMapper _mapper;

    public ContractService(
        IContractRepository repository,
        IVehicleContractService vehicleContractService,
        HajjSystemContext context,
        IMapper mapper,
        ICompanyRepository companyRepository,
        IVendorRepository vendorRepository)
    {
        _repository = repository;
        _vehicleContractService = vehicleContractService;
        _context = context;
        _mapper = mapper;
        _companyRepository = companyRepository;
        _vendorRepository = vendorRepository;
    }

    public async Task<IEnumerable<Contract>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Contract?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Contract?> GetByIdWithDetailsAsync(int id)
    {
        return await _repository.GetByIdWithDetailsAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<Contract> CreateAsync(Contract contract)
    {
        return await _repository.AddAsync(contract);
    }

    public async Task<Contract> UpdateAsync(Contract contract)
    {
        return await _repository.UpdateAsync(contract);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // First, check if contract exists
            var exists = await _repository.ExistsAsync(id);
            if (!exists) return false;

            // Delete all vehicle contracts first
            var vehicleContracts = await _vehicleContractService.GetByContractIdAsync(id);
            if (vehicleContracts.Any())
            {
                foreach (var vehicleContract in vehicleContracts)
                {
                    await _vehicleContractService.DeleteAsync(vehicleContract.Id);
                }
            }

            // Then delete the contract
            var deleted = await _repository.DeleteAsync(id);
            
            await transaction.CommitAsync();
            return deleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ContractService] Delete Exception: {ex.Message}\\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<OperationResponse> CreateWithDetailsAsync(ContractCreateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var contract = _mapper.Map<Contract>(model);
            var modelVehicleContracts = model.VehicleContracts;
            
            // Don't set navigation properties, only foreign keys
            contract.Company = null;
            contract.Vendor = null;
            contract.Season = null;
            contract.VehicleContracts = null;
            
            var created = await _repository.AddAsync(contract);

            // Map and set only the foreign key IDs, not the navigation properties
            if (modelVehicleContracts != null && modelVehicleContracts.Any())
            {
                var vehicleContracts = _mapper.Map<List<VehicleContract>>(modelVehicleContracts);
                foreach (var vc in vehicleContracts)
                {
                    vc.ContractId = created.Id;
                    vc.CompanyId = model.CompanyId;
                    // Don't set navigation properties
                }
                
                await _vehicleContractService.SaveListAsync(vehicleContracts);
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Contract created successfully" };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ContractService] Exception: {ex.Message}\\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error creating contract." };
        }
    }

    public async Task<OperationResponse> UpdateWithDetailsAsync(ContractUpdateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Check if contract exists
            var exists = await _repository.ExistsAsync(model.Id);
            if (!exists)
            {
                return new OperationResponse { Status = false, Message = "Contract not found" };
            }

            // Update contract
            var contract = _mapper.Map<Contract>(model);
            await _repository.UpdateAsync(contract);

            // Handle vehicle contracts
            if (model.VehicleContracts != null && model.VehicleContracts.Any())
            {
                // Get existing vehicle contracts
                var existingContracts = await _vehicleContractService.GetByContractIdAsync(model.Id);
                var existingContractIds = existingContracts.Select(d => d.Id).ToList();
                var modelContractIds = model.VehicleContracts
                    .Where(d => d != null && d.Id > 0)
                    .Select(d => d.Id)
                    .ToList();

                // Delete vehicle contracts that are not in the update model
                foreach (var existingId in existingContractIds)
                {
                    if (!modelContractIds.Contains(existingId))
                    {
                        await _vehicleContractService.DeleteAsync(existingId);
                    }
                }

                // Update or create vehicle contracts
                foreach (var contractModel in model.VehicleContracts)
                {
                    var vehicleContract = _mapper.Map<VehicleContract>(contractModel);
                    vehicleContract.ContractId = model.Id;
                    vehicleContract.CompanyId = model.CompanyId;
                if (contractModel.Id.HasValue){
                    if (contractModel.Id > 0 && existingContractIds.Contains(contractModel.Id.Value))
                    {
                        // Update existing contract
                        await _vehicleContractService.UpdateAsync(vehicleContract);
                    }
                }else
                    {
                        // Create new contract
                        await _vehicleContractService.CreateAsync(vehicleContract);
                    }
                }
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Contract updated successfully" };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ContractService] Update Exception: {ex.Message}\\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error updating contract." };
        }
    }

    public async Task<IEnumerable<Contract>> SearchContractsAsync(ContractSearchModel model)
    {
        return await _repository.SearchContractsAsync(model);
    }
}
