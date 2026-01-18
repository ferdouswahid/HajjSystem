using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface ILocationService
{
    Task<IEnumerable<Location>> GetAllAsync();
    Task<Location?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<Location> CreateAsync(Location location);
    Task<Location> UpdateAsync(Location location);
    Task<bool> DeleteAsync(int id);
}
