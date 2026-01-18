using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class VehicleContractRepository : IVehicleContractRepository
{
    private readonly HajjSystemContext _context;

    public VehicleContractRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VehicleContract>> GetAllAsync()
    {
        return await _context.VehicleContracts
            .Include(vc => vc.Vehicle)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<VehicleContract?> GetByIdAsync(int id)
    {
        return await _context.VehicleContracts
            .Include(vc => vc.Vehicle)
            .FirstOrDefaultAsync(vc => vc.Id == id);
    }

    public async Task<VehicleContract> AddAsync(VehicleContract vehicleContract)
    {
        var entry = await _context.VehicleContracts.AddAsync(vehicleContract);
        await _context.SaveChangesAsync();
        
        // Load the Vehicle navigation property
        await _context.Entry(entry.Entity).Reference(vc => vc.Vehicle).LoadAsync();
        
        return entry.Entity;
    }

    public async Task<VehicleContract> UpdateAsync(VehicleContract vehicleContract)
    {
        _context.Entry(vehicleContract).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return vehicleContract;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.VehicleContracts.FindAsync(id);
        if (entity is null) return false;
        _context.VehicleContracts.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.VehicleContracts.AnyAsync(vc => vc.Id == id);
    }
}
