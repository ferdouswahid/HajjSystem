using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _repository;

    public LocationService(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Location?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<Location> CreateAsync(Location location)
    {
        return await _repository.AddAsync(location);
    }

    public async Task<Location> UpdateAsync(Location location)
    {
        return await _repository.UpdateAsync(location);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
