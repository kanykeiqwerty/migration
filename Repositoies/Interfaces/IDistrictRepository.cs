using MigrationApi.Models;

namespace MigrationApi.Repositories.Interfaces
{
    public interface IDistrictRepository
    {
        Task<List<District>> GetAllAsync();
        Task<District?> GetByIdAsync(int id);
        Task AddAsync(District district);
        Task UpdateAsync(District district);
        Task DeleteAsync(District district);
        Task<bool> RegionExistsAsync(int id);
        Task SaveAsync();

    }
}