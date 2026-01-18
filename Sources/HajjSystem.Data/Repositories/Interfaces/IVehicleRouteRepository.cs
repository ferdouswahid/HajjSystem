using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IVehicleRouteRepository
{
    Task<IEnumerable<VehicleRoute>> GetAllAsync();
    Task<VehicleRoute?> GetByIdAsync(int id);
    Task<VehicleRoute> AddAsync(VehicleRoute vehicleRoute);
    Task<VehicleRoute> UpdateAsync(VehicleRoute vehicleRoute);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
}
