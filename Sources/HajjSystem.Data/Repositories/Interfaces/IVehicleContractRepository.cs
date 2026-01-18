using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IVehicleContractRepository
{
    Task<IEnumerable<VehicleContract>> GetAllAsync();
    Task<VehicleContract?> GetByIdAsync(int id);
    Task<VehicleContract> AddAsync(VehicleContract vehicleContract);
    Task<VehicleContract> UpdateAsync(VehicleContract vehicleContract);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
