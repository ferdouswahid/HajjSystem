using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> GetAllAsync();
    Task<Package?> GetByIdAsync(int id);
    Task<Package?> GetByIdWithDetailsAsync(int id);
    Task<Package> AddAsync(Package package);
    Task<Package> UpdateAsync(Package package);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<Package>> SearchPackagesAsync(PackageSearchModel model);
}
