using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _context;
        public RegionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions
            .ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(int id)
        {
            return await _context.Regions
            .Include(r => r.District)
            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Region region) => await _context.Regions.AddAsync(region);

        public async Task UpdateAsync(Region region)
        {
            _context.Regions.Update(region);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Region region)
        {
            _context.Regions.Remove(region);
            await Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}