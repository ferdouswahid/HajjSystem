using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Repositories.Interfaces;

public interface IOrderDetailRepository
{
    Task<IEnumerable<OrderDetail>> GetAllAsync();
    Task<OrderDetail?> GetByIdAsync(int id);
    Task<OrderDetail?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);
    Task<OrderDetail> AddAsync(OrderDetail orderDetail);
    Task AddRangeAsync(List<OrderDetail> orderDetails);
    Task<OrderDetail> UpdateAsync(OrderDetail orderDetail);
    Task<bool> DeleteAsync(int id);
    Task<bool> DeleteByOrderIdAsync(int orderId);
    Task<bool> ExistsAsync(int id);
}
