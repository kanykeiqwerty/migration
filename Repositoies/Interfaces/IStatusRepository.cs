using MigrationApi.Models;

namespace MigrationApi.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllAsync();
        Task<Status?> GetByIdAsync(int id);
        Task AddAsync(Status status);
        Task UpdateAsync(Status status);
        Task DeleteAsync(Status status);
        Task SaveAsync();

    }
}