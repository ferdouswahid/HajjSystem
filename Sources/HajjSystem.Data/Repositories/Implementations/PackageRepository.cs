using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Data.Repositories.Implementations;

public class PackageRepository : IPackageRepository
{
    private readonly HajjSystemContext _context;

    public PackageRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Package>> GetAllAsync()
    {
        return await _context.Packages.AsNoTracking().ToListAsync();
    }

    public async Task<Package?> GetByIdAsync(int id)
    {
        return await _context.Packages.FindAsync(id);
    }

    public async Task<Package?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Packages
            .Include(p => p.PackageType)
            .Include(p => p.Company)
            .Include(p => p.Season)
            .Include(p => p.PackageVehicles!)
                .ThenInclude(pv => pv.VehicleDetail)
            .Include(p => p.PackageVehicles!)
                .ThenInclude(pv => pv.Contract)
            .Include(p => p.PackageAirlines)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Package> AddAsync(Package package)
    {
        await _context.Packages.AddAsync(package);
        await _context.SaveChangesAsync();
        return package;
    }

    public async Task<Package> UpdateAsync(Package package)
    {
        _context.Packages.Update(package);
        await _context.SaveChangesAsync();
        return package;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var package = await _context.Packages.FindAsync(id);
        if (package == null) return false;

        _context.Packages.Remove(package);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Packages.AnyAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Package>> SearchPackagesAsync(PackageSearchModel model)
    {
        var query = _context.Packages
            .Include(p => p.PackageType)
            .Include(p => p.Company)
            .Include(p => p.Season)
            .Include(p => p.PackageVehicles!)
                .ThenInclude(pv => pv.VehicleDetail)
            .Include(p => p.PackageVehicles!)
                .ThenInclude(pv => pv.VehicleContract)
            .Include(p => p.PackageVehicles!)
                .ThenInclude(pv => pv.Contract)
            .AsNoTracking()
            .AsQueryable();

        if (model.Id.HasValue)
        {
            query = query.Where(p => p.Id == model.Id.Value);
        }

        if (model.Ids != null && model.Ids.Any())
        {
            query = query.Where(p => model.Ids.Contains(p.Id));
        }

        if (model.PackageTypeId.HasValue)
        {
            query = query.Where(p => p.PackageTypeId == model.PackageTypeId.Value);
        }

        if (model.CompanyId.HasValue)
        {
            query = query.Where(p => p.CompanyId == model.CompanyId.Value);
        }

        if (model.SeasonId.HasValue)
        {
            query = query.Where(p => p.SeasonId == model.SeasonId.Value);
        }

        if (!string.IsNullOrEmpty(model.Title))
        {
            query = query.Where(p => p.Title.Contains(model.Title));
        }

        if (model.StartDate.HasValue)
        {
            query = query.Where(p => p.StartDate >= model.StartDate.Value);
        }

        if (model.EndDate.HasValue)
        {
            query = query.Where(p => p.EndDate <= model.EndDate.Value);
        }

        return await query.ToListAsync();
    }
}
