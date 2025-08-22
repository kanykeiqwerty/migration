using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles
            .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles
            .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task AddAsync(Role role) => await _context.Roles.AddAsync(role);

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
            await Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}