using MigrationApi.Models;

namespace MigrationApi.Repositories.Interfaces
{
    public interface IMigrationRepository
    {
        Task<List<Migration>> GetAllAsync();
        Task<Migration?> GetByIdAsync(Guid id);
        Task<CitizenForm?> GetCitizenFormByIdAsync(Guid id);
        Task AddAsync(Migration migration);
        Task UpdateAsync(Migration migration);
        Task UpdateCitizenFormAsync(CitizenForm form);
        Task DeleteAsync(Migration migration);
        Task<bool> CountryExistsAsync(int id);
        Task SaveAsync();

    }
}