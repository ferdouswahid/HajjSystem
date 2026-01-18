using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class VehicleRepository : IVehicleRepository
{
    private readonly HajjSystemContext _context;

    public VehicleRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles
            .Include(v => v.Company)
            .Include(v => v.Vendor)
            .Include(v => v.VehicleDetails)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Vehicle?> GetByIdAsync(int id)
    {
        return await _context.Vehicles
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Vehicle?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Vehicles
            .Include(v => v.Company)
            .Include(v => v.Vendor)
            .Include(v => v.VehicleDetails)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Vehicle> AddAsync(Vehicle vehicle)
    {
        var entry = await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        _context.Entry(vehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Vehicles.FindAsync(id);
        if (entity is null) return false;
        _context.Vehicles.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Vehicles.AnyAsync(v => v.Id == id);
    }
}
