using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Services.Interfaces;

public interface IPackageService
{
    Task<IEnumerable<Package>> GetAllAsync();
    Task<Package?> GetByIdAsync(int id);
    Task<Package?> GetByIdWithDetailsAsync(int id);
    Task<Package> CreateAsync(Package package);
    Task<Package> UpdateAsync(Package package);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<OperationResponse> CreateWithDetailsAsync(PackageCreateModel model);
    Task<OperationResponse> UpdateWithDetailsAsync(PackageUpdateModel model);
    Task<IEnumerable<Package>> SearchPackagesAsync(PackageSearchModel model);
}
