using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IPackageTypeRepository
{
    Task<IEnumerable<PackageType>> GetAllAsync();
    Task<PackageType?> GetByIdAsync(int id);
    Task<PackageType> AddAsync(PackageType packageType);
    Task<PackageType> UpdateAsync(PackageType packageType);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<PackageType>> SearchPackageTypesAsync(PackageTypeSearchModel model);
}
