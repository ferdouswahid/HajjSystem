using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IPackageVehicleRepository
{
    Task<IEnumerable<PackageVehicle>> GetAllAsync();
    Task<PackageVehicle?> GetByIdAsync(int id);
    Task<PackageVehicle?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<PackageVehicle>> GetByPackageIdAsync(int packageId);
    Task<PackageVehicle> AddAsync(PackageVehicle packageVehicle);
    Task AddRangeAsync(List<PackageVehicle> packageVehicles);
    Task<PackageVehicle> UpdateAsync(PackageVehicle packageVehicle);
    Task<bool> DeleteAsync(int id);
    Task<bool> DeleteByPackageIdAsync(int packageId);
    Task<bool> ExistsAsync(int id);
}
