using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Data.Repositories.Implementations;

public class PackageVehicleRepository : IPackageVehicleRepository
{
    private readonly HajjSystemContext _context;

    public PackageVehicleRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PackageVehicle>> GetAllAsync()
    {
        return await _context.PackageVehicles.AsNoTracking().ToListAsync();
    }

    public async Task<PackageVehicle?> GetByIdAsync(int id)
    {
        return await _context.PackageVehicles.FindAsync(id);
    }

    public async Task<PackageVehicle?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.PackageVehicles
            .Include(pv => pv.Package)
            .Include(pv => pv.Contract)
            .Include(pv => pv.VehicleDetail)
            .Include(pv => pv.Season)
            .Include(pv => pv.Company)
            .AsNoTracking()
            .FirstOrDefaultAsync(pv => pv.Id == id);
    }

    public async Task<IEnumerable<PackageVehicle>> GetByPackageIdAsync(int packageId)
    {
        return await _context.PackageVehicles
            .Where(pv => pv.PackageId == packageId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PackageVehicle> AddAsync(PackageVehicle packageVehicle)
    {
        await _context.PackageVehicles.AddAsync(packageVehicle);
        await _context.SaveChangesAsync();
        return packageVehicle;
    }

    public async Task AddRangeAsync(List<PackageVehicle> packageVehicles)
    {
        await _context.PackageVehicles.AddRangeAsync(packageVehicles);
        await _context.SaveChangesAsync();
    }

    public async Task<PackageVehicle> UpdateAsync(PackageVehicle packageVehicle)
    {
        _context.PackageVehicles.Update(packageVehicle);
        await _context.SaveChangesAsync();
        return packageVehicle;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var packageVehicle = await _context.PackageVehicles.FindAsync(id);
        if (packageVehicle == null) return false;

        _context.PackageVehicles.Remove(packageVehicle);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByPackageIdAsync(int packageId)
    {
        var packageVehicles = await _context.PackageVehicles
            .Where(pv => pv.PackageId == packageId)
            .ToListAsync();

        if (!packageVehicles.Any()) return false;

        _context.PackageVehicles.RemoveRange(packageVehicles);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.PackageVehicles.AnyAsync(pv => pv.Id == id);
    }
}
