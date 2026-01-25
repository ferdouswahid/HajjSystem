using HajjSystem.Data;
using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;

namespace HajjSystem.Services.Implementations;

public class PackageService : IPackageService
{
    private readonly IPackageRepository _repository;
    private readonly IPackageVehicleService _packageVehicleService;
    private readonly HajjSystemContext _context;
    private readonly IMapper _mapper;

    public PackageService(
        IPackageRepository repository,
        IPackageVehicleService packageVehicleService,
        HajjSystemContext context,
        IMapper mapper)
    {
        _repository = repository;
        _packageVehicleService = packageVehicleService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Package>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Package?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Package?> GetByIdWithDetailsAsync(int id)
    {
        return await _repository.GetByIdWithDetailsAsync(id);
    }

    public async Task<Package> CreateAsync(Package package)
    {
        return await _repository.AddAsync(package);
    }

    public async Task<Package> UpdateAsync(Package package)
    {
        return await _repository.UpdateAsync(package);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var exists = await _repository.ExistsAsync(id);
            if (!exists) return false;

            // Delete all package vehicles first
            var packageVehicles = await _packageVehicleService.GetByPackageIdAsync(id);
            if (packageVehicles.Any())
            {
                foreach (var pv in packageVehicles)
                {
                    await _packageVehicleService.DeleteAsync(pv.Id);
                }
            }

            // Then delete the package
            var deleted = await _repository.DeleteAsync(id);
            
            await transaction.CommitAsync();
            return deleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PackageService] Delete Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<OperationResponse> CreateWithDetailsAsync(PackageCreateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var package = _mapper.Map<Package>(model);
            var modelPackageVehicles = model.PackageVehicles;
            package.PackageVehicles = null; // Temporarily set to null to avoid issues during creation
            var created = await _repository.AddAsync(package);

            if (modelPackageVehicles != null && modelPackageVehicles.Any())
            {
                var packageVehicles = _mapper.Map<List<PackageVehicle>>(modelPackageVehicles);
                foreach (var pv in packageVehicles)
                {
                    pv.PackageId = created.Id;
                }
                
                await _packageVehicleService.SaveListAsync(packageVehicles);
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Package created successfully" };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PackageService] Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error creating package." };
        }
    }

    public async Task<OperationResponse> UpdateWithDetailsAsync(PackageUpdateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var exists = await _repository.ExistsAsync(model.Id);
            if (!exists)
            {
                return new OperationResponse { Status = false, Message = "Package not found" };
            }

            // Update package
            var package = _mapper.Map<Package>(model);
            await _repository.UpdateAsync(package);

            // Handle package vehicles
            if (model.PackageVehicles != null && model.PackageVehicles.Any())
            {
                // Get existing package vehicles
                var existingVehicles = await _packageVehicleService.GetByPackageIdAsync(model.Id);
                var existingVehicleIds = existingVehicles.Select(v => v.Id).ToList();
                var modelVehicleIds = model.PackageVehicles
                    .Where(v => v != null && v.Id.HasValue && v.Id.Value > 0)
                    .Select(v => v.Id!.Value)
                    .ToList();

                // Delete package vehicles that are not in the update model
                foreach (var existingId in existingVehicleIds)
                {
                    if (!modelVehicleIds.Contains(existingId))
                    {
                        await _packageVehicleService.DeleteAsync(existingId);
                    }
                }

                // Update or create package vehicles
                foreach (var vehicleModel in model.PackageVehicles)
                {
                    var packageVehicle = _mapper.Map<PackageVehicle>(vehicleModel);
                    packageVehicle.PackageId = model.Id;

                    if (vehicleModel.Id.HasValue && vehicleModel.Id.Value > 0 && existingVehicleIds.Contains(vehicleModel.Id.Value))
                    {
                        // Update existing vehicle
                        await _packageVehicleService.UpdateAsync(packageVehicle);
                    }
                    else
                    {
                        // Create new vehicle
                        await _packageVehicleService.CreateAsync(packageVehicle);
                    }
                }
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Package updated successfully" };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PackageService] Update Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error updating package." };
        }
    }

    public async Task<IEnumerable<Package>> SearchPackagesAsync(PackageSearchModel model)
    {
        return await _repository.SearchPackagesAsync(model);
    }
}
