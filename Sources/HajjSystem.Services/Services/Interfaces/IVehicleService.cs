using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

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
    Task<OperationResponse> CreateWithDetailsAsync(VehicleCreateModel model);
    Task<OperationResponse> UpdateWithDetailsAsync(VehicleUpdateModel model);
    Task<IEnumerable<Vehicle>> SearchVehiclesAsync(VehicleSearchModel model);
}
