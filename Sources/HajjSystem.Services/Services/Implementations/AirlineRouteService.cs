using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class AirlineRouteService : IAirlineRouteService
{
    private readonly IAirlineRouteRepository _repository;

    public AirlineRouteService(IAirlineRouteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AirlineRoute>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<AirlineRoute?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<AirlineRoute> CreateAsync(AirlineRoute airlineRoute)
    {
        return await _repository.AddAsync(airlineRoute);
    }

    public async Task<AirlineRoute> UpdateAsync(AirlineRoute airlineRoute)
    {
        return await _repository.UpdateAsync(airlineRoute);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
