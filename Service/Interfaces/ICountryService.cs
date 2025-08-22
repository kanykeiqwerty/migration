using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetAllAsync();
        Task<CountryDto?> GetByIdAsync(int id);
        Task<Country> CreateAsync(CountryDto dto);
        Task<bool> UpdateAsync(int id, CountryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}