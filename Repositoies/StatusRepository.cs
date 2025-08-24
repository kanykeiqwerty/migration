using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _context.Statuses
            .ToListAsync();
        }

        public async Task<Status?> GetByIdAsync(int id)
        {
            return await _context.Statuses
            .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task AddAsync(Status status) => await _context.Statuses.AddAsync(status);

        public async Task UpdateAsync(Status status)

        {

            _context.Statuses.Update(status);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Status status)
        {
            _context.Statuses.Remove(status);
            await Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}