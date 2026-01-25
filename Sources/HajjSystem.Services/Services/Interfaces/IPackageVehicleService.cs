using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IPackageVehicleService
{
    Task<IEnumerable<PackageVehicle>> GetAllAsync();
    Task<PackageVehicle?> GetByIdAsync(int id);
    Task<PackageVehicle?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<PackageVehicle>> GetByPackageIdAsync(int packageId);
    Task<PackageVehicle> CreateAsync(PackageVehicle packageVehicle);
    Task<PackageVehicle> UpdateAsync(PackageVehicle packageVehicle);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task SaveListAsync(List<PackageVehicle> packageVehicles);
}
