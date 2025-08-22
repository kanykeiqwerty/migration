using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries
            .ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries
            .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task AddAsync(Country country) => await _context.Countries.AddAsync(country);

        public async Task UpdateAsync(Country country)
        {
            _context.Countries.Update(country);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Country country)
        {
            _context.Countries.Remove(country);
            await Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}