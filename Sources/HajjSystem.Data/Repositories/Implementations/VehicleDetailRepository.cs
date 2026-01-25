using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
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

    public async Task<bool> DeleteByVehicleIdAsync(int vehicleId)
    {
        var entities = await _context.VehicleDetails
            .Where(vd => vd.VehicleId == vehicleId)
            .ToListAsync();
        
        if (!entities.Any()) return true; // No details to delete
        
        _context.VehicleDetails.RemoveRange(entities);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.VehicleDetails.AnyAsync(vd => vd.Id == id);
    }

    public async Task<IEnumerable<VehicleDetail>> SearchVehicleDetailsAsync(VehicleDetailSearchModel model)
    {
        var query = _context.VehicleDetails
            .Include(vd => vd.Vehicle)
            .Include(vd => vd.RouteFrom)
            .Include(vd => vd.RouteTo)
            .AsQueryable();

        if (model.Id.HasValue)
            query = query.Where(vd => vd.Id == model.Id.Value);

        if (model.Ids != null && model.Ids.Any())
            query = query.Where(vd => model.Ids.Contains(vd.Id));

        if (model.VehicleId.HasValue)
            query = query.Where(vd => vd.VehicleId == model.VehicleId.Value);

        if (model.RouteFromId.HasValue)
            query = query.Where(vd => vd.RouteFromId == model.RouteFromId.Value);

        if (model.RouteToId.HasValue)
            query = query.Where(vd => vd.RouteToId == model.RouteToId.Value);

        if (model.TripType.HasValue)
            query = query.Where(vd => vd.TripType == model.TripType.Value);

        if (model.MinPrice.HasValue)
            query = query.Where(vd => vd.Price >= model.MinPrice.Value);

        if (model.MaxPrice.HasValue)
            query = query.Where(vd => vd.Price <= model.MaxPrice.Value);

        if (model.DepartureDate.HasValue)
            query = query.Where(vd => vd.DepartureDate.Date == model.DepartureDate.Value.Date);

        if (model.CompanyId.HasValue)
            query = query.Where(vd => vd.CompanyId == model.CompanyId.Value);

        return await query.AsNoTracking().ToListAsync();
    }
}
