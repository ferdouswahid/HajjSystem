using HajjSystem.Data;
using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Enums;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using System.Linq;

namespace HajjSystem.Services.Implementations;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;
    private readonly IVehicleDetailService _vehicleDetailService;
    private readonly ICompanyRepository _companyRepository;
    private readonly IVendorRepository _vendorRepository;
    private readonly HajjSystemContext _context;
    private readonly IMapper _mapper;

    public VehicleService(IVehicleRepository repository, IVehicleDetailService vehicleDetailService, HajjSystemContext context, 
    IMapper mapper, ICompanyRepository companyRepository, IVendorRepository vendorRepository)
    {
        _repository = repository;
        _vehicleDetailService = vehicleDetailService;
        _context = context;
        _mapper = mapper;
        _companyRepository = companyRepository;
        _vendorRepository = vendorRepository;
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Vehicle?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }


    public async Task<Vehicle?> GetByIdWithDetailsAsync(int id)
    {
        return await _repository.GetByIdWithDetailsAsync(id);
    }

    public async Task<Vehicle> CreateAsync(Vehicle vehicle)
    {
        return await _repository.AddAsync(vehicle);
    }

    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        return await _repository.UpdateAsync(vehicle);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // First, check if vehicle exists
            var exists = await _repository.ExistsAsync(id);
            if (!exists) return false;

            // Delete all vehicle details first
            var vehicleDetails = await _vehicleDetailService.GetByVehicleIdAsync(id);
            if (vehicleDetails.Any())
            {
                foreach (var detail in vehicleDetails)
                {
                    await _vehicleDetailService.DeleteAsync(detail.Id);
                }
            }

            // Then delete the vehicle
            var deleted = await _repository.DeleteAsync(id);
            
            await transaction.CommitAsync();
            return deleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[VehicleService] Delete Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<OperationResponse> CreateWithDetailsAsync(VehicleCreateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var vehicle = _mapper.Map<Vehicle>(model);
            var modelVehicleDetails = model.VehicleDetails;
            var companyDb = _companyRepository.GetByIdAsync(model.CompanyId).Result;
            vehicle.Company = companyDb;
            vehicle.Vendor = _vendorRepository.GetByIdAsync(model.VendorId).Result; // To avoid EF Core tracking issues
            vehicle.VehicleDetails = null; // Avoid setting navigation property directly
            var created = await _repository.AddAsync(vehicle);

            // Map and set only the foreign key IDs, not the navigation properties
            if (modelVehicleDetails != null && modelVehicleDetails.Any())
            {
                var vehicleDetails = _mapper.Map<List<VehicleDetail>>(modelVehicleDetails);
                foreach (var vd in vehicleDetails)
                {
                    vd.VehicleId = created.Id;
                    vd.Company = companyDb;
                    // Do not set navigation properties to avoid EF Core tracking issues
                }

                await _vehicleDetailService.SaveListAsync(vehicleDetails);
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Vehicle created successfully" };
        }
        catch (Exception ex)
        {
            // Log the exception stack trace for debugging
            Console.WriteLine($"[VehicleService] Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error creating vehicle." };
        }
    }

    public async Task<OperationResponse> UpdateWithDetailsAsync(VehicleUpdateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Check if vehicle exists
            var exists = await _repository.ExistsAsync(model.Id);
            if (!exists)
            {
                return new OperationResponse { Status = false, Message = "Vehicle not found" };
            }

            // Update vehicle
            var vehicle = _mapper.Map<Vehicle>(model);
            var modelVehicleDetails = model.VehicleDetails;
            vehicle.VehicleDetails = null; // Avoid setting navigation property directly

            await _repository.UpdateAsync(vehicle);

            // Handle vehicle details
            if (modelVehicleDetails != null && modelVehicleDetails.Any())
            {
                // Get existing vehicle details
                var existingDetails = await _vehicleDetailService.GetByVehicleIdAsync(model.Id);
                var existingDetailIds = existingDetails.Select(d => d.Id).ToList();
                var modelDetailIds = modelVehicleDetails
                    .Where(d => d != null && d.Id > 0)
                    .Select(d => d.Id)
                    .ToList();

                // Delete vehicle details that are not in the update model
                foreach (var existingId in existingDetailIds)
                {
                    if (!modelDetailIds.Contains(existingId))
                    {
                        await _vehicleDetailService.DeleteAsync(existingId);
                    }
                }

                // Update or create vehicle details
                foreach (var detailModel in modelVehicleDetails)
                {
                    var vehicleDetail = _mapper.Map<VehicleDetail>(detailModel);
                    vehicleDetail.VehicleId = model.Id;
                    vehicleDetail.CompanyId = model.CompanyId;
                    

                    if (detailModel.Id.HasValue){
                    if (detailModel.Id > 0  && existingDetailIds.Contains(detailModel.Id.Value))
                    {
                        // Update existing detail
                        await _vehicleDetailService.UpdateAsync(vehicleDetail);
                    }
                    }
                    else
                    {
                        // Create new detail
                        await _vehicleDetailService.CreateAsync(vehicleDetail);
                    }
                }
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Vehicle updated successfully" };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[VehicleService] Update Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error updating vehicle." };
        }
    }

    public async Task<IEnumerable<Vehicle>> SearchVehiclesAsync(VehicleSearchModel model)
    {
        return await _repository.SearchVehiclesAsync(model);
    }
}
