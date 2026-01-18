using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class MealTypeRepository : IMealTypeRepository
{
    private readonly HajjSystemContext _context;

    public MealTypeRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MealType>> GetAllAsync()
    {
        return await _context.MealTypes.AsNoTracking().ToListAsync();
    }

    public async Task<MealType?> GetByIdAsync(int id)
    {
        return await _context.MealTypes.FindAsync(id);
    }

    public async Task<MealType> AddAsync(MealType mealType)
    {
        var entry = await _context.MealTypes.AddAsync(mealType);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<MealType> UpdateAsync(MealType mealType)
    {
        _context.Entry(mealType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return mealType;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.MealTypes.FindAsync(id);
        if (entity is null) return false;
        _context.MealTypes.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.MealTypes.AnyAsync(m => m.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
    {
        if (excludeId.HasValue)
        {
            return await _context.MealTypes.AnyAsync(m => m.Name == name && m.Id != excludeId.Value);
        }
        return await _context.MealTypes.AnyAsync(m => m.Name == name);
    }
}
