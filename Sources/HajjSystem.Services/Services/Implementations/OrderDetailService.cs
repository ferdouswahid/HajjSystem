using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Services.Interfaces;

namespace HajjSystem.Services.Implementations;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository _repository;

    public OrderDetailService(IOrderDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrderDetail>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<OrderDetail?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<OrderDetail?> GetByIdWithDetailsAsync(int id)
    {
        return await _repository.GetByIdWithDetailsAsync(id);
    }

    public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
    {
        return await _repository.GetByOrderIdAsync(orderId);
    }

    public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
    {
        return await _repository.AddAsync(orderDetail);
    }

    public async Task<OrderDetail> UpdateAsync(OrderDetail orderDetail)
    {
        var exists = await _repository.ExistsAsync(orderDetail.Id);
        if (!exists)
        {
            throw new ArgumentException($"OrderDetail with ID {orderDetail.Id} does not exist.");
        }

        return await _repository.UpdateAsync(orderDetail);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task SaveListAsync(List<OrderDetail> orderDetails)
    {
        await _repository.AddRangeAsync(orderDetails);
    }
}
