using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class VehicleRouteService : IVehicleRouteService
{
    private readonly IVehicleRouteRepository _repository;

    public VehicleRouteService(IVehicleRouteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VehicleRoute>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<VehicleRoute?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
    {
        return await _repository.ExistsByNameAsync(name, excludeId);
    }

    public async Task<VehicleRoute> CreateAsync(VehicleRoute vehicleRoute)
    {
        return await _repository.AddAsync(vehicleRoute);
    }

    public async Task<VehicleRoute> UpdateAsync(VehicleRoute vehicleRoute)
    {
        return await _repository.UpdateAsync(vehicleRoute);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
