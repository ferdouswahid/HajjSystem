using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class AirlineRouteRepository : IAirlineRouteRepository
{
    private readonly HajjSystemContext _context;

    public AirlineRouteRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AirlineRoute>> GetAllAsync()
    {
        return await _context.AirlineRoutes.AsNoTracking().ToListAsync();
    }

    public async Task<AirlineRoute?> GetByIdAsync(int id)
    {
        return await _context.AirlineRoutes.FindAsync(id);
    }

    public async Task<AirlineRoute> AddAsync(AirlineRoute airlineRoute)
    {
        var entry = await _context.AirlineRoutes.AddAsync(airlineRoute);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<AirlineRoute> UpdateAsync(AirlineRoute airlineRoute)
    {
        _context.Entry(airlineRoute).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return airlineRoute;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.AirlineRoutes.FindAsync(id);
        if (entity is null) return false;
        _context.AirlineRoutes.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.AirlineRoutes.AnyAsync(a => a.Id == id);
    }
}
