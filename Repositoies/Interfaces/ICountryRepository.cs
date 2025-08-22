using MigrationApi.Models;

namespace MigrationApi.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(int id);
        Task AddAsync(Country country);
        Task UpdateAsync(Country country);
        Task DeleteAsync(Country country);
        Task SaveAsync();

    }
}