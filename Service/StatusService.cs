using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repo;
        public StatusService(IStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<StatusDto>> GetAllAsync()
        {
            var status = await _repo.GetAllAsync();
            return status.Select(c => new StatusDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

        }

        public async Task<StatusDto?> GetByIdAsync(int id)
        {
            var status = await _repo.GetByIdAsync(id);

            if (status == null) return null;

            return new StatusDto
            {
                Id = status.Id,
                Name = status.Name
            };
        }

        public async Task<Status> CreateAsync(StatusDto dto)
        {
            var newstatus = new Status
            {
                Name = dto.Name
            };

            await _repo.AddAsync(newstatus);
            await _repo.SaveAsync();
            return newstatus;
        }

        public async Task<bool> UpdateAsync(int id, StatusDto dto)
        {
            var status = await _repo.GetByIdAsync(id);
            if (status == null) return false;

            status.Name = dto.Name;

            await _repo.UpdateAsync(status);
            await _repo.SaveAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _repo.GetByIdAsync(id);
            if (status == null) return false;

            await _repo.DeleteAsync(status);
            await _repo.SaveAsync();
            return true;
        }
    }
}