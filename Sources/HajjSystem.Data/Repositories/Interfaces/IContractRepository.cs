using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IContractRepository
{
    Task<IEnumerable<Contract>> GetAllAsync();
    Task<Contract?> GetByIdAsync(int id);
    Task<Contract?> GetByIdWithDetailsAsync(int id);
    Task<Contract> AddAsync(Contract contract);
    Task<Contract> UpdateAsync(Contract contract);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<Contract>> SearchContractsAsync(ContractSearchModel model);
}
