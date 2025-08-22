using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class MaritalStatusRepository : IMaritalStatusRepository
    {
        private readonly AppDbContext _context;

        public MaritalStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MaritalStatus>> GetAllAsync()
        {
            return await _context.MaritalStatuses
            .ToListAsync();
        }

        public async Task<MaritalStatus?> GetByIdAsync(int id)
        {
            return await _context.MaritalStatuses
            .FirstOrDefaultAsync(mc => mc.Id == id);

        }

        public async Task AddAsync(MaritalStatus maritalStatus) => await _context.MaritalStatuses.AddAsync(maritalStatus);

        public async Task UpdateAsync(MaritalStatus maritalStatus)
        {
            _context.MaritalStatuses.Update(maritalStatus);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(MaritalStatus maritalStatus)
        {
            _context.MaritalStatuses.Remove(maritalStatus);
            await Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}