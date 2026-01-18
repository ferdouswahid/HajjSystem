using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IAirlineRouteRepository
{
    Task<IEnumerable<AirlineRoute>> GetAllAsync();
    Task<AirlineRoute?> GetByIdAsync(int id);
    Task<AirlineRoute> AddAsync(AirlineRoute airlineRoute);
    Task<AirlineRoute> UpdateAsync(AirlineRoute airlineRoute);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
