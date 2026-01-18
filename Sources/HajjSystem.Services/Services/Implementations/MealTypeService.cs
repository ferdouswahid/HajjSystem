using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class MealTypeService : IMealTypeService
{
    private readonly IMealTypeRepository _repository;

    public MealTypeService(IMealTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MealType>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<MealType?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
    {
        return await _repository.ExistsByNameAsync(name, excludeId);
    }

    public async Task<MealType> CreateAsync(MealType mealType)
    {
        return await _repository.AddAsync(mealType);
    }

    public async Task<MealType> UpdateAsync(MealType mealType)
    {
        return await _repository.UpdateAsync(mealType);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
