using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class PackageTypeService : IPackageTypeService
{
    private readonly IPackageTypeRepository _repository;

    public PackageTypeService(IPackageTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PackageType>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<PackageType?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<PackageType> CreateAsync(PackageType packageType)
    {
        return await _repository.AddAsync(packageType);
    }

    public async Task<PackageType> UpdateAsync(PackageType packageType)
    {
        return await _repository.UpdateAsync(packageType);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PackageType>> SearchPackageTypesAsync(PackageTypeSearchModel model)
    {
        return await _repository.SearchPackageTypesAsync(model);
    }
}
