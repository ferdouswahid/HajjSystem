using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Services.Interfaces;

public interface IVehicleContractService
{
    Task<IEnumerable<VehicleContract>> GetAllAsync();
    Task<VehicleContract?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<VehicleContract> CreateAsync(VehicleContract vehicleContract);
    Task<VehicleContract> UpdateAsync(VehicleContract vehicleContract);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<VehicleContract>> GetByContractIdAsync(int contractId);
    Task SaveListAsync(List<VehicleContract> vehicleContracts);
    Task<IEnumerable<VehicleContract>> SearchVehicleContractsAsync(VehicleContractSearchModel model);
}
