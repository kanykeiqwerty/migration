using MigrationApi.Models;

namespace MigrationApi.Repositories.Interfaces
{
    public interface ICitizenFormRepository
    {
        Task<List<CitizenForm>> GetAllAsync();
        Task<CitizenForm?> GetByIdAsync(Guid id);
        Task AddAsync(CitizenForm form);
        Task UpdateAsync(CitizenForm form);
        Task DeleteAsync(CitizenForm form);
        Task<bool> DistrictExistsAsync(int id);
        Task<bool> MaritalStatusExistsAsync(int id);
        Task<bool> StatusExistsAsync(int id);
        Task SaveAsync();
    }
}
