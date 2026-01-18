using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IVehicleDetailRepository
{
    Task<IEnumerable<VehicleDetail>> GetAllAsync();
    Task<VehicleDetail?> GetByIdAsync(int id);
    Task<VehicleDetail?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<VehicleDetail>> GetByVehicleIdAsync(int vehicleId);
    Task<VehicleDetail> AddAsync(VehicleDetail vehicleDetail);
    Task AddRangeAsync(List<VehicleDetail> vehicleDetails);
    Task<VehicleDetail> UpdateAsync(VehicleDetail vehicleDetail);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
