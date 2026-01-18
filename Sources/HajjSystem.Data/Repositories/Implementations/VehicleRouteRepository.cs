using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class VehicleRouteRepository : IVehicleRouteRepository
{
    private readonly HajjSystemContext _context;

    public VehicleRouteRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VehicleRoute>> GetAllAsync()
    {
        return await _context.VehicleRoutes.AsNoTracking().ToListAsync();
    }

    public async Task<VehicleRoute?> GetByIdAsync(int id)
    {
        return await _context.VehicleRoutes.FindAsync(id);
    }

    public async Task<VehicleRoute> AddAsync(VehicleRoute vehicleRoute)
    {
        var entry = await _context.VehicleRoutes.AddAsync(vehicleRoute);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<VehicleRoute> UpdateAsync(VehicleRoute vehicleRoute)
    {
        _context.Entry(vehicleRoute).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return vehicleRoute;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.VehicleRoutes.FindAsync(id);
        if (entity is null) return false;
        _context.VehicleRoutes.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.VehicleRoutes.AnyAsync(v => v.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
    {
        if (excludeId.HasValue)
        {
            return await _context.VehicleRoutes.AnyAsync(v => v.Name == name && v.Id != excludeId.Value);
        }
        return await _context.VehicleRoutes.AnyAsync(v => v.Name == name);
    }
}
