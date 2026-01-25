using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class VehicleContractService : IVehicleContractService
{
    private readonly IVehicleContractRepository _repository;

    public VehicleContractService(IVehicleContractRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VehicleContract>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<VehicleContract?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<VehicleContract> CreateAsync(VehicleContract vehicleContract)
    {
        return await _repository.AddAsync(vehicleContract);
    }

    public async Task<VehicleContract> UpdateAsync(VehicleContract vehicleContract)
    {
        return await _repository.UpdateAsync(vehicleContract);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<VehicleContract>> GetByContractIdAsync(int contractId)
    {
        var allContracts = await _repository.GetAllAsync();
        return allContracts.Where(vc => vc.ContractId == contractId);
    }

    public async Task SaveListAsync(List<VehicleContract> vehicleContracts)
    {
        foreach (var vehicleContract in vehicleContracts)
        {
            await _repository.AddAsync(vehicleContract);
        }
    }

    public async Task<IEnumerable<VehicleContract>> SearchVehicleContractsAsync(VehicleContractSearchModel model)
    {
        var items = await _repository.GetAllAsync();

        if (model.Id.HasValue)
            items = items.Where(x => x.Id == model.Id.Value);

        if (model.Ids != null && model.Ids.Length > 0)
            items = items.Where(x => model.Ids.Contains(x.Id));

        if (model.VehicleId.HasValue)
            items = items.Where(x => x.VehicleId == model.VehicleId.Value);

        if (model.ContractId.HasValue)
            items = items.Where(x => x.ContractId == model.ContractId.Value);

        if (model.CompanyId.HasValue)
            items = items.Where(x => x.CompanyId == model.CompanyId.Value);

        if (model.MinAgreedSeat.HasValue)
            items = items.Where(x => x.AgreedSeat >= model.MinAgreedSeat.Value);

        if (model.MaxAgreedSeat.HasValue)
            items = items.Where(x => x.AgreedSeat <= model.MaxAgreedSeat.Value);

        return items;
    }
}
