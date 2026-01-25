using HajjSystem.Models.Entities;
using HajjSystem.Models.Enums;
using HajjSystem.Models.Models;
using HajjSystem.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Data.Repositories.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly HajjSystemContext _context;

    public OrderRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.AsNoTracking().ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<Order?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.PilgrimCompany)
            .Include(o => o.Company)
            .Include(o => o.OrderDetails!)
                .ThenInclude(od => od.Package)
            .Include(o => o.OrderLogs)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order> AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Orders.AnyAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> SearchOrdersAsync(OrderSearchModel model)
    {
        var query = _context.Orders
            .Include(o => o.User)
            .Include(o => o.PilgrimCompany)
            .Include(o => o.Company)
            .Include(o => o.OrderDetails!)
                .ThenInclude(od => od.Package)
            .AsNoTracking()
            .AsQueryable();

        if (model.Id.HasValue)
        {
            query = query.Where(o => o.Id == model.Id.Value);
        }

        if (model.Ids != null && model.Ids.Any())
        {
            query = query.Where(o => model.Ids.Contains(o.Id));
        }

        if (model.UserId.HasValue)
        {
            query = query.Where(o => o.UserId == model.UserId.Value);
        }

        if (model.PilgrimCompanyId.HasValue)
        {
            query = query.Where(o => o.PilgrimCompanyId == model.PilgrimCompanyId.Value);
        }

        if (model.CompanyId.HasValue)
        {
            query = query.Where(o => o.CompanyId == model.CompanyId.Value);
        }

        if (!string.IsNullOrEmpty(model.InvoiceNo))
        {
            query = query.Where(o => o.InvoiceNo.Contains(model.InvoiceNo));
        }

        if (model.Status.HasValue)
        {
            query = query.Where(o => o.Status == model.Status.Value);
        }

        if (model.StartDate.HasValue)
        {
            query = query.Where(o => o.Date >= model.StartDate.Value);
        }

        if (model.EndDate.HasValue)
        {
            query = query.Where(o => o.Date <= model.EndDate.Value);
        }

        return await query.ToListAsync();
    }
}
