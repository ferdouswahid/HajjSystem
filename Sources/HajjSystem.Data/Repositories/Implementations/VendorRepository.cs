using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class VendorRepository : IVendorRepository
{
    private readonly HajjSystemContext _context;

    public VendorRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vendor>> GetAllAsync()
    {
        return await _context.Vendors
            .Include(v => v.Company)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Vendor?> GetByIdAsync(int id)
    {
        return await _context.Vendors
            .Include(v => v.Company)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Vendor> AddAsync(Vendor vendor)
    {
        var entry = await _context.Vendors.AddAsync(vendor);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Vendor> UpdateAsync(Vendor vendor)
    {
        _context.Entry(vendor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return vendor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Vendors.FindAsync(id);
        if (entity is null) return false;
        _context.Vendors.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Vendors.AnyAsync(s => s.Id == id);
    }

    public async Task<bool> ExistsByCrNumberAsync(string crNumber, int? excludeId = null)
    {
        if (excludeId.HasValue)
        {
            return await _context.Vendors.AnyAsync(s => s.CrNumber == crNumber && s.Id != excludeId.Value);
        }
        return await _context.Vendors.AnyAsync(s => s.CrNumber == crNumber);
    }
}
