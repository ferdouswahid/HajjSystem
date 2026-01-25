using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;

namespace HajjSystem.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order?> GetByIdWithDetailsAsync(int id);
    Task<Order> CreateAsync(Order order);
    Task<Order> UpdateAsync(Order order);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<OperationResponse> CreateWithDetailsAsync(OrderCreateModel model);
    Task<OperationResponse> UpdateWithDetailsAsync(OrderUpdateModel model);
    Task<IEnumerable<Order>> SearchOrdersAsync(OrderSearchModel model);
}
