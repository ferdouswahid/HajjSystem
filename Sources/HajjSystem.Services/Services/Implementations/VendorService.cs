using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class VendorService : IVendorService
{
    private readonly IVendorRepository _repository;

    public VendorService(IVendorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Vendor>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Vendor?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<bool> ExistsByCrNumberAsync(string crNumber, int? excludeId = null)
    {
        return await _repository.ExistsByCrNumberAsync(crNumber, excludeId);
    }

    public async Task<Vendor> CreateAsync(Vendor vendor)
    {
        return await _repository.AddAsync(vendor);
    }

    public async Task<Vendor> UpdateAsync(Vendor vendor)
    {
        return await _repository.UpdateAsync(vendor);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
