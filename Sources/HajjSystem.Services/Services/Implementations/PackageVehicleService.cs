using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class PackageVehicleService : IPackageVehicleService
{
    private readonly IPackageVehicleRepository _repository;

    public PackageVehicleService(IPackageVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PackageVehicle>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<PackageVehicle?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<PackageVehicle?> GetByIdWithDetailsAsync(int id)
    {
        return await _repository.GetByIdWithDetailsAsync(id);
    }

    public async Task<IEnumerable<PackageVehicle>> GetByPackageIdAsync(int packageId)
    {
        return await _repository.GetByPackageIdAsync(packageId);
    }

    public async Task<PackageVehicle> CreateAsync(PackageVehicle packageVehicle)
    {
        return await _repository.AddAsync(packageVehicle);
    }

    public async Task<PackageVehicle> UpdateAsync(PackageVehicle packageVehicle)
    {
        var exists = await _repository.ExistsAsync(packageVehicle.Id);
        if (!exists)
        {
            throw new ArgumentException($"PackageVehicle with ID {packageVehicle.Id} does not exist.");
        }

        return await _repository.UpdateAsync(packageVehicle);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task SaveListAsync(List<PackageVehicle> packageVehicles)
    {
        await _repository.AddRangeAsync(packageVehicles);
    }
}
