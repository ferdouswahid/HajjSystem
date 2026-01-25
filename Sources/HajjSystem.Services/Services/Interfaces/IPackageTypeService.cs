using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Services.Interfaces;

public interface IPackageTypeService
{
    Task<IEnumerable<PackageType>> GetAllAsync();
    Task<PackageType?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<PackageType> CreateAsync(PackageType packageType);
    Task<PackageType> UpdateAsync(PackageType packageType);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<PackageType>> SearchPackageTypesAsync(PackageTypeSearchModel model);
}
