using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> GetAllAsync();
    Task<Vehicle?> GetByIdAsync(int id);
    Task<Vehicle?> GetByIdWithDetailsAsync(int id);
    Task<Vehicle> CreateAsync(Vehicle vehicle);
    Task<Vehicle> UpdateAsync(Vehicle vehicle);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
