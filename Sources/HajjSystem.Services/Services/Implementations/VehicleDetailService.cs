using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class VehicleDetailService : IVehicleDetailService
{
    private readonly IVehicleDetailRepository _repository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IVehicleRouteRepository _vehicleRouteRepository;

    public VehicleDetailService(
        IVehicleDetailRepository repository,
        IVehicleRepository vehicleRepository,
        IVehicleRouteRepository vehicleRouteRepository)
    {
        _repository = repository;
        _vehicleRepository = vehicleRepository;
        _vehicleRouteRepository = vehicleRouteRepository;
    }

    public async Task<IEnumerable<VehicleDetail>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<VehicleDetail?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<VehicleDetail?> GetByIdWithDetailsAsync(int id)
    {
        return await _repository.GetByIdWithDetailsAsync(id);
    }

    public async Task<IEnumerable<VehicleDetail>> GetByVehicleIdAsync(int vehicleId)
    {
        return await _repository.GetByVehicleIdAsync(vehicleId);
    }

    public async Task<VehicleDetail> CreateAsync(VehicleDetail vehicleDetail)
    {
        // Validate foreign keys exist
        var vehicleExists = await _vehicleRepository.ExistsAsync(vehicleDetail.VehicleId);
        if (!vehicleExists)
        {
            throw new ArgumentException($"Vehicle with ID {vehicleDetail.VehicleId} does not exist.");
        }

        var routeFromExists = await _vehicleRouteRepository.ExistsAsync(vehicleDetail.RouteFromId);
        if (!routeFromExists)
        {
            throw new ArgumentException($"Route with ID {vehicleDetail.RouteFromId} does not exist.");
        }

        var routeToExists = await _vehicleRouteRepository.ExistsAsync(vehicleDetail.RouteToId);
        if (!routeToExists)
        {
            throw new ArgumentException($"Route with ID {vehicleDetail.RouteToId} does not exist.");
        }

        return await _repository.AddAsync(vehicleDetail);
    }

    public async Task<VehicleDetail> UpdateAsync(VehicleDetail vehicleDetail)
    {
        // Check if entity exists
        var exists = await _repository.ExistsAsync(vehicleDetail.Id);
        if (!exists)
        {
            throw new ArgumentException($"VehicleDetail with ID {vehicleDetail.Id} does not exist.");
        }

        // Validate foreign keys exist
        var vehicleExists = await _vehicleRepository.ExistsAsync(vehicleDetail.VehicleId);
        if (!vehicleExists)
        {
            throw new ArgumentException($"Vehicle with ID {vehicleDetail.VehicleId} does not exist.");
        }

        var routeFromExists = await _vehicleRouteRepository.ExistsAsync(vehicleDetail.RouteFromId);
        if (!routeFromExists)
        {
            throw new ArgumentException($"Route with ID {vehicleDetail.RouteFromId} does not exist.");
        }

        var routeToExists = await _vehicleRouteRepository.ExistsAsync(vehicleDetail.RouteToId);
        if (!routeToExists)
        {
            throw new ArgumentException($"Route with ID {vehicleDetail.RouteToId} does not exist.");
        }

        return await _repository.UpdateAsync(vehicleDetail);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task saveListAsync(List<VehicleDetail> vehicleDetails)
    {
        await _repository.AddRangeAsync(vehicleDetails);
    }
}
