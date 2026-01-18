using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllAsync();
    Task<Location?> GetByIdAsync(int id);
    Task<Location> AddAsync(Location location);
    Task<Location> UpdateAsync(Location location);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
