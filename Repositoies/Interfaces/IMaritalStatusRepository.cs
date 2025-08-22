using MigrationApi.Models;

namespace MigrationApi.Repositories.Interfaces
{
    public interface IMaritalStatusRepository
    {
        Task<List<MaritalStatus>> GetAllAsync();
        Task<MaritalStatus?> GetByIdAsync(int id);
        Task AddAsync(MaritalStatus maritalStatus);
        Task UpdateAsync(MaritalStatus maritalStatus);
        Task DeleteAsync(MaritalStatus maritalStatus);
        Task SaveAsync();

    }
}