using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IVehicleRouteService
{
    Task<IEnumerable<VehicleRoute>> GetAllAsync();
    Task<VehicleRoute?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
    Task<VehicleRoute> CreateAsync(VehicleRoute vehicleRoute);
    Task<VehicleRoute> UpdateAsync(VehicleRoute vehicleRoute);
    Task<bool> DeleteAsync(int id);
}
