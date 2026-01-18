using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class LocationRepository : ILocationRepository
{
    private readonly HajjSystemContext _context;

    public LocationRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await _context.Locations.AsNoTracking().ToListAsync();
    }

    public async Task<Location?> GetByIdAsync(int id)
    {
        return await _context.Locations.FindAsync(id);
    }

    public async Task<Location> AddAsync(Location location)
    {
        var entry = await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Location> UpdateAsync(Location location)
    {
        _context.Entry(location).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return location;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Locations.FindAsync(id);
        if (entity is null) return false;
        _context.Locations.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Locations.AnyAsync(l => l.Id == id);
    }
}
