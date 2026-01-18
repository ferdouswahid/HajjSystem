using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class VehicleDetailRepository : IVehicleDetailRepository
{
    private readonly HajjSystemContext _context;

    public VehicleDetailRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VehicleDetail>> GetAllAsync()
    {
        return await _context.VehicleDetails
            .Include(vd => vd.Vehicle)
            .Include(vd => vd.RouteFrom)
            .Include(vd => vd.RouteTo)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<VehicleDetail?> GetByIdAsync(int id)
    {
        return await _context.VehicleDetails
            .FirstOrDefaultAsync(vd => vd.Id == id);
    }

    public async Task<VehicleDetail?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.VehicleDetails
            .Include(vd => vd.Vehicle)
            .Include(vd => vd.RouteFrom)
            .Include(vd => vd.RouteTo)
            .FirstOrDefaultAsync(vd => vd.Id == id);
    }

    public async Task<IEnumerable<VehicleDetail>> GetByVehicleIdAsync(int vehicleId)
    {
        return await _context.VehicleDetails
            .Include(vd => vd.RouteFrom)
            .Include(vd => vd.RouteTo)
            .Where(vd => vd.VehicleId == vehicleId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<VehicleDetail> AddAsync(VehicleDetail vehicleDetail)
    {
        var entry = await _context.VehicleDetails.AddAsync(vehicleDetail);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task AddRangeAsync(List<VehicleDetail> vehicleDetails)
    {
        await _context.VehicleDetails.AddRangeAsync(vehicleDetails);
        await _context.SaveChangesAsync();
    }

    public async Task<VehicleDetail> UpdateAsync(VehicleDetail vehicleDetail)
    {
        _context.Entry(vehicleDetail).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return vehicleDetail;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.VehicleDetails.FindAsync(id);
        if (entity is null) return false;
        _context.VehicleDetails.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.VehicleDetails.AnyAsync(vd => vd.Id == id);
    }
}
