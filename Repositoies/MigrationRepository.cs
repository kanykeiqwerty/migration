using Microsoft.EntityFrameworkCore;
using MigrationApi.Models;
using MigrationApi.Data;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class MigrationRepository : IMigrationRepository
    {
        private readonly AppDbContext _context;

        public MigrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Migration>> GetAllAsync()
        {
            return await _context.Migrations
            .Include(m => m.Country)
            .ToListAsync();

        }
        public async Task<Migration?> GetByIdAsync(Guid id)
        {
            return await _context.Migrations
            .Include(m => m.Country)
            .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Migration migration) => await _context.Migrations.AddAsync(migration);

        public async Task UpdateAsync(Migration migration)
        {
            _context.Migrations.Update(migration);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Migration migration)
        {
            _context.Migrations.Remove(migration);
            await Task.CompletedTask;
        }

        public async Task<bool> CountryExistsAsync(int id) => await _context.Countries.AnyAsync(c => c.Id == id);
        
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        
        
    }
}