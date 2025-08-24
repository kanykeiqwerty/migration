using MigrationApi.Models;

namespace MigrationApi.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(int id);
        Task AddAsync(Region region);
        Task UpdateAsync(Region region);
        Task DeleteAsync(Region region);
        Task SaveAsync();
    }
}