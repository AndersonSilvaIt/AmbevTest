using DeveloperStore.Users.Domain.Entities;

namespace DeveloperStore.Users.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<(List<User> Users, int TotalItems)> GetAllAsync(int pageIndex, int pageSize, string orderBy = null);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
