using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IVehicleDetailService
{
    Task<IEnumerable<VehicleDetail>> GetAllAsync();
    Task<VehicleDetail?> GetByIdAsync(int id);
    Task<VehicleDetail?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<VehicleDetail>> GetByVehicleIdAsync(int vehicleId);
    Task<VehicleDetail> CreateAsync(VehicleDetail vehicleDetail);
    Task<VehicleDetail> UpdateAsync(VehicleDetail vehicleDetail);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task saveListAsync(List<VehicleDetail> vehicleDetails);
}
