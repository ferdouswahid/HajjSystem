using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IMealTypeService
{
    Task<IEnumerable<MealType>> GetAllAsync();
    Task<MealType?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
    Task<MealType> CreateAsync(MealType mealType);
    Task<MealType> UpdateAsync(MealType mealType);
    Task<bool> DeleteAsync(int id);
}
