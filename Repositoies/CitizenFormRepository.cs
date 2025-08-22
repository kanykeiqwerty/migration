using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;

namespace MigrationApi.Repositories
{
    public class CitizenFormRepository : ICitizenFormRepository
    {
        private readonly AppDbContext _context;

        public CitizenFormRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CitizenForm>> GetAllAsync()
        {
            return await _context.CitizenForms
            .Include(f => f.District).ThenInclude(d => d.Region)
            .Include(f => f.Migrations).ThenInclude(m => m.Country)
            .ToListAsync();
        }

         public async Task<CitizenForm?> GetByIdAsync(Guid id)
        {
            return await _context.CitizenForms
                .Include(f => f.District).ThenInclude(d => d.Region)
                .Include(f => f.Migrations).ThenInclude(m => m.Country)
                .Include(f => f.Status)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(CitizenForm form) => await _context.CitizenForms.AddAsync(form);

        public async Task UpdateAsync(CitizenForm form)
        {
            _context.CitizenForms.Update(form);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(CitizenForm form)
        {
            _context.CitizenForms.Remove(form);
            await Task.CompletedTask;
        }

        public async Task<bool> DistrictExistsAsync(int id) => await _context.Districts.AnyAsync(d => d.Id == id);
        public async Task<bool> MaritalStatusExistsAsync(int id) => await _context.MaritalStatuses.AnyAsync(m => m.Id == id);
        public async Task<bool> StatusExistsAsync(int id) => await _context.Statuses.AnyAsync(s => s.Id == id);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}

    