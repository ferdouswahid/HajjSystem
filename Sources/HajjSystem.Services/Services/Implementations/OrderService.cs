using HajjSystem.Data;
using HajjSystem.Data.Repositories.Interfaces;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;

namespace HajjSystem.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IOrderDetailService _orderDetailService;
    private readonly HajjSystemContext _context;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository repository,
        IOrderDetailService orderDetailService,
        HajjSystemContext context,
        IMapper mapper)
    {
        _repository = repository;
        _orderDetailService = orderDetailService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Order?> GetByIdWithDetailsAsync(int id)
    {
        return await _repository.GetByIdWithDetailsAsync(id);
    }

    public async Task<Order> CreateAsync(Order order)
    {
        return await _repository.AddAsync(order);
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        return await _repository.UpdateAsync(order);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var exists = await _repository.ExistsAsync(id);
            if (!exists) return false;

            // Delete all order details first
            var orderDetails = await _orderDetailService.GetByOrderIdAsync(id);
            if (orderDetails.Any())
            {
                foreach (var detail in orderDetails)
                {
                    await _orderDetailService.DeleteAsync(detail.Id);
                }
            }

            // Then delete the order
            var deleted = await _repository.DeleteAsync(id);
            
            await transaction.CommitAsync();
            return deleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[OrderService] Delete Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<OperationResponse> CreateWithDetailsAsync(OrderCreateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var order = _mapper.Map<Order>(model);
            var modelOrderDetails = model.OrderDetails;
            order.OrderDetails = null; // Temporarily set to null to avoid issues during creation
            var created = await _repository.AddAsync(order);

            if (modelOrderDetails != null && modelOrderDetails.Any())
            {
                var orderDetails = _mapper.Map<List<OrderDetail>>(modelOrderDetails);
                foreach (var od in orderDetails)
                {
                    od.OrderId = created.Id;
                }
                
                await _orderDetailService.SaveListAsync(orderDetails);
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Order created successfully" };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[OrderService] Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error creating order." };
        }
    }

    public async Task<OperationResponse> UpdateWithDetailsAsync(OrderUpdateModel model)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var exists = await _repository.ExistsAsync(model.Id);
            if (!exists)
            {
                return new OperationResponse { Status = false, Message = "Order not found" };
            }

            // Update order
            var order = _mapper.Map<Order>(model);
            await _repository.UpdateAsync(order);

            // Handle order details
            if (model.OrderDetails != null && model.OrderDetails.Any())
            {
                // Get existing order details
                var existingDetails = await _orderDetailService.GetByOrderIdAsync(model.Id);
                var existingDetailIds = existingDetails.Select(d => d.Id).ToList();
                var modelDetailIds = model.OrderDetails
                    .Where(d => d != null && d.Id.HasValue && d.Id.Value > 0)
                    .Select(d => d.Id!.Value)
                    .ToList();

                // Delete order details that are not in the update model
                foreach (var existingId in existingDetailIds)
                {
                    if (!modelDetailIds.Contains(existingId))
                    {
                        await _orderDetailService.DeleteAsync(existingId);
                    }
                }

                // Update or create order details
                foreach (var detailModel in model.OrderDetails)
                {
                    var orderDetail = _mapper.Map<OrderDetail>(detailModel);
                    orderDetail.OrderId = model.Id;

                    if (detailModel.Id.HasValue && detailModel.Id.Value > 0 && existingDetailIds.Contains(detailModel.Id.Value))
                    {
                        // Update existing detail
                        await _orderDetailService.UpdateAsync(orderDetail);
                    }
                    else
                    {
                        // Create new detail
                        await _orderDetailService.CreateAsync(orderDetail);
                    }
                }
            }

            await transaction.CommitAsync();
            return new OperationResponse { Status = true, Message = "Order updated successfully" };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[OrderService] Update Exception: {ex.Message}\n{ex.StackTrace}");
            await transaction.RollbackAsync();
            return new OperationResponse { Status = false, Message = "Error updating order." };
        }
    }

    public async Task<IEnumerable<Order>> SearchOrdersAsync(OrderSearchModel model)
    {
        return await _repository.SearchOrdersAsync(model);
    }
}
