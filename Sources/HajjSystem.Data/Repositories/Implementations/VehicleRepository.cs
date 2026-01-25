using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
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
                .ThenInclude(vd => vd.RouteFrom)
            .Include(v => v.VehicleDetails)
                .ThenInclude(vd => vd.RouteTo)
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
                .ThenInclude(vd => vd.RouteFrom)
            .Include(v => v.VehicleDetails)
                .ThenInclude(vd => vd.RouteTo)
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

    public async Task<IEnumerable<Vehicle>> SearchVehiclesAsync(VehicleSearchModel model)
    {
        var query = _context.Vehicles
            .Include(v => v.Company)
            .Include(v => v.Vendor)
            .Include(v => v.VehicleDetails)
                .ThenInclude(vd => vd.RouteFrom)
            .Include(v => v.VehicleDetails)
                .ThenInclude(vd => vd.RouteTo)
            .AsQueryable();

        query = query.Where(v => v.CompanyId == model.CompanyId);

        // Filter by single Id
        if (model.Id.HasValue)
        {
            query = query.Where(v => v.Id == model.Id.Value);
        }

        // Filter by multiple Ids
/*         if (model.Ids != null && model.Ids.Length > 0)
        {
            query = query.Where(v => model.Ids.Contains(v.Id));
        } */

        // Apply filters based on VehicleSearchModel properties
        if (!string.IsNullOrWhiteSpace(model.EngineNumber))
        {
            query = query.Where(v => v.EngineNumber != null && v.EngineNumber.Contains(model.EngineNumber));
        }

        if (!string.IsNullOrWhiteSpace(model.ChassisNumber))
        {
            query = query.Where(v => v.ChassisNumber != null && v.ChassisNumber.Contains(model.ChassisNumber));
        }

        if (!string.IsNullOrWhiteSpace(model.Color))
        {
            query = query.Where(v => v.Color != null && v.Color.Contains(model.Color));
        }

        if (!string.IsNullOrWhiteSpace(model.Model))
        {
            query = query.Where(v => v.Model != null && v.Model.Contains(model.Model));
        }

        if (model.Year.HasValue)
        {
            query = query.Where(v => v.Year == model.Year.Value);
        }

        if (!string.IsNullOrWhiteSpace(model.LicensePlate))
        {
            query = query.Where(v => v.LicensePlate.Contains(model.LicensePlate));
        }

        if (model.VehicleType.HasValue)
        {
            query = query.Where(v => v.VehicleType == model.VehicleType.Value);
        }

        if (model.TotalSeat.HasValue)
        {
            query = query.Where(v => v.TotalSeat == model.TotalSeat.Value);
        }

        if (!string.IsNullOrWhiteSpace(model.Features))
        {
            query = query.Where(v => v.Features != null && v.Features.Contains(model.Features));
        }

        if (!string.IsNullOrWhiteSpace(model.Status))
        {
            query = query.Where(v => v.Status != null && v.Status.Contains(model.Status));
        }



        if (model.VendorId.HasValue)
        {
            query = query.Where(v => v.VendorId == model.VendorId.Value);
        }

        return await query.AsNoTracking().ToListAsync();
    }
}
