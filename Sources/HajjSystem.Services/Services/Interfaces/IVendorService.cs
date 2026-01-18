using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IVendorService
{
    Task<IEnumerable<Vendor>> GetAllAsync();
    Task<Vendor?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsByCrNumberAsync(string crNumber, int? excludeId = null);
    Task<Vendor> CreateAsync(Vendor vendor);
    Task<Vendor> UpdateAsync(Vendor vendor);
    Task<bool> DeleteAsync(int id);
}
