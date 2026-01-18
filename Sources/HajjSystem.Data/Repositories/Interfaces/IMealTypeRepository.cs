using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IMealTypeRepository
{
    Task<IEnumerable<MealType>> GetAllAsync();
    Task<MealType?> GetByIdAsync(int id);
    Task<MealType> AddAsync(MealType mealType);
    Task<MealType> UpdateAsync(MealType mealType);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
}
