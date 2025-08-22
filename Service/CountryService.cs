using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repo;
        public CountryService(ICountryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var country = await _repo.GetAllAsync();
            return country.Select(c => new CountryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

        }

        public async Task<CountryDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);

            if (c == null) return null;

            return new CountryDto
            {
                Id = c.Id,
                Name = c.Name
            };
        }

        public async Task<Country> CreateAsync(CountryDto dto)
        {
            var newcountry = new Country
            {
                Name = dto.Name
            };

            await _repo.AddAsync(newcountry);
            await _repo.SaveAsync();
            return newcountry;
        }

        public async Task<bool> UpdateAsync(int id, CountryDto dto)
        {
            var country = await _repo.GetByIdAsync(id);
            if (country == null) return false;

            country.Name = dto.Name;

            await _repo.UpdateAsync(country);
            await _repo.SaveAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var country = await _repo.GetByIdAsync(id);
            if (country == null) return false;

            await _repo.DeleteAsync(country);
            await _repo.SaveAsync();
            return true;
        }
    }
}