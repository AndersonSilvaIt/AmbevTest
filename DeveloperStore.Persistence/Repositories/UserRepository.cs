using DeveloperStore.Persistence.Context;
using DeveloperStore.Users.Domain.Entities;
using DeveloperStore.Users.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Persistence.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Address)
                .ThenInclude(a => a.Geolocation)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<(List<User> Users, int TotalItems)> GetAllAsync(int pageIndex, int pageSize, string orderBy = null)
        {
            var queryable = _context.Users.AsQueryable();

            if(!string.IsNullOrEmpty(orderBy))
            {
                var orderParams = orderBy.Split(',');
                foreach(var param in orderParams)
                {
                    var trimmed = param.Trim();
                    var sortBy = trimmed.Split(' ')[0];  // Exemple: "Username"
                    var direction = trimmed.Length > 1 && trimmed.Contains("desc") ? "desc" : "asc";

                    if(direction == "desc")
                    {
                        queryable = queryable.OrderByDescending(e => EF.Property<object>(e, sortBy));
                    } 
                    else
                    {
                        queryable = queryable.OrderBy(e => EF.Property<object>(e, sortBy));
                    }
                }
            }

            var users = await queryable
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize) 
                .ToListAsync();

            var totalItems = await queryable.CountAsync();

            return (users, totalItems);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }
    }
}
