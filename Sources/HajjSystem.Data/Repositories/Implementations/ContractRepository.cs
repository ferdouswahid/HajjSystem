using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class ContractRepository : IContractRepository
{
    private readonly HajjSystemContext _context;

    public ContractRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contract>> GetAllAsync()
    {
        return await _context.Contracts
            .Include(c => c.Vendor)
            .Include(c => c.Company)
            .Include(c => c.Season)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Contract?> GetByIdAsync(int id)
    {
        return await _context.Contracts
            .Include(c => c.Vendor)
            .Include(c => c.Company)
            .Include(c => c.Season)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Contract?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Contracts
            .Include(c => c.Vendor)
            .Include(c => c.Company)
            .Include(c => c.Season)
            .Include(c => c.VehicleContracts)
                .ThenInclude(vc => vc.Vehicle)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Contract> AddAsync(Contract contract)
    {
        var entry = await _context.Contracts.AddAsync(contract);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Contract> UpdateAsync(Contract contract)
    {
        _context.Entry(contract).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Contracts.FindAsync(id);
        if (entity is null) return false;
        _context.Contracts.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Contracts.AnyAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Contract>> SearchContractsAsync(ContractSearchModel model)
    {
        var query = _context.Contracts
            .Include(c => c.Vendor)
            .Include(c => c.Company)
            .Include(c => c.Season)
            .Include(c => c.VehicleContracts)
                .ThenInclude(vc => vc.Vehicle)
            .AsQueryable();

        query = query.Where(c => c.CompanyId == model.CompanyId);

        // Filter by single Id
        if (model.Id.HasValue)
        {
            query = query.Where(c => c.Id == model.Id.Value);
        }

        // Filter by multiple Ids
        if (model.Ids != null && model.Ids.Length > 0)
        {
            query = query.Where(c => model.Ids.Contains(c.Id));
        }

        // Filter by Title
        if (!string.IsNullOrWhiteSpace(model.Title))
        {
            query = query.Where(c => c.Title.Contains(model.Title));
        }

        // Filter by VendorId
        if (model.VendorId.HasValue)
        {
            query = query.Where(c => c.VendorId == model.VendorId.Value);
        }

        // Filter by ContractType
        if (model.ContractType.HasValue)
        {
            query = query.Where(c => c.ContractType == model.ContractType.Value);
        }

        // Filter by StartDate
        if (model.StartDate.HasValue)
        {
            query = query.Where(c => c.StartDate >= model.StartDate.Value);
        }

        // Filter by EndDate
        if (model.EndDate.HasValue)
        {
            query = query.Where(c => c.EndDate <= model.EndDate.Value);
        }

        // Filter by Status
        if (!string.IsNullOrWhiteSpace(model.Status))
        {
            query = query.Where(c => c.Status.Contains(model.Status));
        }

        // Filter by SeasonId
        if (model.SeasonId.HasValue)
        {
            query = query.Where(c => c.SeasonId == model.SeasonId.Value);
        }

        return await query.AsNoTracking().ToListAsync();
    }
}
