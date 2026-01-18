using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IAirlineRouteService
{
    Task<IEnumerable<AirlineRoute>> GetAllAsync();
    Task<AirlineRoute?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<AirlineRoute> CreateAsync(AirlineRoute airlineRoute);
    Task<AirlineRoute> UpdateAsync(AirlineRoute airlineRoute);
    Task<bool> DeleteAsync(int id);
}
