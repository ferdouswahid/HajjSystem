using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Data.Repositories.Interfaces;

namespace HajjSystem.Data.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly HajjSystemContext _context;

    public UserRepository(HajjSystemContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        var entry = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<IEnumerable<User>> SearchUsersAsync(UserSearchModel model)
    {
        var query = _context.Users
            .Include(u => u.Company)
            .Include(u => u.Season)
            .AsQueryable();

        if (model.Id.HasValue)
            query = query.Where(u => u.Id == model.Id.Value);

        if (model.Ids != null && model.Ids.Any())
            query = query.Where(u => model.Ids.Contains(u.Id));

        if (!string.IsNullOrWhiteSpace(model.Username))
            query = query.Where(u => u.Username.Contains(model.Username));

        if (!string.IsNullOrWhiteSpace(model.Email))
            query = query.Where(u => u.Email.Contains(model.Email));

        if (!string.IsNullOrWhiteSpace(model.FirstName))
            query = query.Where(u => u.FirstName != null && u.FirstName.Contains(model.FirstName));

        if (!string.IsNullOrWhiteSpace(model.LastName))
            query = query.Where(u => u.LastName != null && u.LastName.Contains(model.LastName));

        if (model.UserType.HasValue)
            query = query.Where(u => u.UserType == model.UserType.Value);

        if (model.CompanyId.HasValue)
            query = query.Where(u => u.CompanyId == model.CompanyId.Value);

        if (model.SeasonId.HasValue)
            query = query.Where(u => u.SeasonId == model.SeasonId.Value);

        if (!string.IsNullOrWhiteSpace(model.Mobile))
            query = query.Where(u => u.Mobile.Contains(model.Mobile));

        if (!string.IsNullOrWhiteSpace(model.City))
            query = query.Where(u => u.City.Contains(model.City));

        if (!string.IsNullOrWhiteSpace(model.Country))
            query = query.Where(u => u.Country.Contains(model.Country));

        return await query.AsNoTracking().ToListAsync();
    }
}
