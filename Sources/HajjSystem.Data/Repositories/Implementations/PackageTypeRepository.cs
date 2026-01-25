using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class PackageTypeRepository : IPackageTypeRepository
{
    private readonly HajjSystemContext _context;

    public PackageTypeRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PackageType>> GetAllAsync()
    {
        return await _context.PackageTypes
            .Include(pt => pt.Company)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PackageType?> GetByIdAsync(int id)
    {
        return await _context.PackageTypes
            .Include(pt => pt.Company)
            .FirstOrDefaultAsync(pt => pt.Id == id);
    }

    public async Task<PackageType> AddAsync(PackageType packageType)
    {
        var entry = await _context.PackageTypes.AddAsync(packageType);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<PackageType> UpdateAsync(PackageType packageType)
    {
        _context.Entry(packageType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return packageType;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.PackageTypes.FindAsync(id);
        if (entity is null) return false;
        _context.PackageTypes.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.PackageTypes.AnyAsync(pt => pt.Id == id);
    }

    public async Task<IEnumerable<PackageType>> SearchPackageTypesAsync(PackageTypeSearchModel model)
    {
        var query = _context.PackageTypes
            .Include(pt => pt.Company)
            .AsQueryable();

            query = query.Where(x => x.CompanyId == model.CompanyId);

        if (model.Id.HasValue)
            query = query.Where(x => x.Id == model.Id.Value);

        if (model.Ids != null && model.Ids.Length > 0)
            query = query.Where(x => model.Ids.Contains(x.Id));

        if (!string.IsNullOrWhiteSpace(model.Name))
            query = query.Where(x => x.Name.Contains(model.Name));

        return await query.AsNoTracking().ToListAsync();
    }
}
