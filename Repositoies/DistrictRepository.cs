using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly AppDbContext _context;

        public DistrictRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<District>> GetAllAsync()
        {
            return await _context.Districts
            .Include(d=>d.Region)
            .ToListAsync();
        }

        public async Task<District?> GetByIdAsync(int id)
        {
            return await _context.Districts
            .Include(d=>d.Region)
            .FirstOrDefaultAsync(d => d.Id == id);

        }

        public async Task AddAsync(District district) => await _context.Districts.AddAsync(district);

        public async Task UpdateAsync(District district)
        {
            _context.Districts.Update(district);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(District district)
        {
            _context.Districts.Remove(district);
            await Task.CompletedTask;
        }

        public async Task<bool> RegionExistsAsync(int id) => await _context.Regions.AnyAsync(r => r.Id == id);
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}