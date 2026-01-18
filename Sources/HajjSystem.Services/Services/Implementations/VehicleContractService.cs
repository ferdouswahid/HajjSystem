using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class VehicleContractService : IVehicleContractService
{
    private readonly IVehicleContractRepository _repository;

    public VehicleContractService(IVehicleContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VehicleContract>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<VehicleContract?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<VehicleContract> CreateAsync(VehicleContract vehicleContract)
    {
        return await _repository.AddAsync(vehicleContract);
    }

    public async Task<VehicleContract> UpdateAsync(VehicleContract vehicleContract)
    {
        return await _repository.UpdateAsync(vehicleContract);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
