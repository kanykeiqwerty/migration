using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IMaritalStatusRepository _repo;
        public MaritalStatusService(IMaritalStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MaritalStatusDto>> GetAllAsync()
        {
            var maritalStatuses = await _repo.GetAllAsync();
            return maritalStatuses.Select(c => new MaritalStatusDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

        }

        public async Task<MaritalStatusDto?> GetByIdAsync(int id)
        {
            var maritalStatus = await _repo.GetByIdAsync(id);

            if (maritalStatus == null) return null;

            return new MaritalStatusDto
            {
                Id = maritalStatus.Id,
                Name = maritalStatus.Name
            };
        }

        public async Task<MaritalStatus> CreateAsync(MaritalStatusDto dto)
        {
            var newmaritalStatus = new MaritalStatus
            {
                Name = dto.Name
            };

            await _repo.AddAsync(newmaritalStatus);
            await _repo.SaveAsync();
            return newmaritalStatus;
        }

        public async Task<bool> UpdateAsync(int id, MaritalStatusDto dto)
        {
            var maritalStatus = await _repo.GetByIdAsync(id);
            if (maritalStatus == null) return false;

            maritalStatus.Name = dto.Name;

            await _repo.UpdateAsync(maritalStatus);
            await _repo.SaveAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var maritalStatus = await _repo.GetByIdAsync(id);
            if (maritalStatus == null) return false;

            await _repo.DeleteAsync(maritalStatus);
            await _repo.SaveAsync();
            return true;
        }
    }
}