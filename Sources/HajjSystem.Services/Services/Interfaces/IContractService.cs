using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Services.Interfaces;

public interface IContractService
{
    Task<IEnumerable<Contract>> GetAllAsync();
    Task<Contract?> GetByIdAsync(int id);
    Task<Contract?> GetByIdWithDetailsAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<Contract> CreateAsync(Contract contract);
    Task<Contract> UpdateAsync(Contract contract);
    Task<bool> DeleteAsync(int id);
    Task<OperationResponse> CreateWithDetailsAsync(ContractCreateModel model);
    Task<OperationResponse> UpdateWithDetailsAsync(ContractUpdateModel model);
    Task<IEnumerable<Contract>> SearchContractsAsync(ContractSearchModel model);
}
