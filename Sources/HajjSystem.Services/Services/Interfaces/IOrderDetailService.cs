using HajjSystem.Models.Entities;

namespace HajjSystem.Services.Interfaces;

public interface IOrderDetailService
{
    Task<IEnumerable<OrderDetail>> GetAllAsync();
    Task<OrderDetail?> GetByIdAsync(int id);
    Task<OrderDetail?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);
    Task<OrderDetail> CreateAsync(OrderDetail orderDetail);
    Task<OrderDetail> UpdateAsync(OrderDetail orderDetail);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task SaveListAsync(List<OrderDetail> orderDetails);
}
