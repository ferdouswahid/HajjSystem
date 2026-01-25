using HajjSystem.Models.Entities;
using HajjSystem.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Data.Repositories.Implementations;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly HajjSystemContext _context;

    public OrderDetailRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderDetail>> GetAllAsync()
    {
        return await _context.OrderDetails.AsNoTracking().ToListAsync();
    }

    public async Task<OrderDetail?> GetByIdAsync(int id)
    {
        return await _context.OrderDetails.FindAsync(id);
    }

    public async Task<OrderDetail?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.OrderDetails
            .Include(od => od.Order)
            .Include(od => od.Package)
            .AsNoTracking()
            .FirstOrDefaultAsync(od => od.Id == id);
    }

    public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<OrderDetail> AddAsync(OrderDetail orderDetail)
    {
        await _context.OrderDetails.AddAsync(orderDetail);
        await _context.SaveChangesAsync();
        return orderDetail;
    }

    public async Task AddRangeAsync(List<OrderDetail> orderDetails)
    {
        await _context.OrderDetails.AddRangeAsync(orderDetails);
        await _context.SaveChangesAsync();
    }

    public async Task<OrderDetail> UpdateAsync(OrderDetail orderDetail)
    {
        _context.OrderDetails.Update(orderDetail);
        await _context.SaveChangesAsync();
        return orderDetail;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var orderDetail = await _context.OrderDetails.FindAsync(id);
        if (orderDetail == null) return false;

        _context.OrderDetails.Remove(orderDetail);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByOrderIdAsync(int orderId)
    {
        var orderDetails = await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .ToListAsync();

        if (!orderDetails.Any()) return false;

        _context.OrderDetails.RemoveRange(orderDetails);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.OrderDetails.AnyAsync(od => od.Id == id);
    }
}
