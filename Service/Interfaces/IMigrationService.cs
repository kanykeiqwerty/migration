using MigrationApi.Models;
using MigrationApi.Dto;

namespace MigrationApi.Service.Interfaces
{
    public interface IMigrationService
    {
        Task<List<MigrationHistoryDto>> GetAllAsync();
        Task<MigrationHistoryDto?> GetByIdAsync(Guid id);
        // Task<OneCitizenFormDto?> GetCitizenFormByIdAsync(Guid id);
        Task<Migration> CreateAsync(MigrationOneDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateMigrationDto dto);
        // Task<bool> UpdateAsync(Guid id, UpdateCitizenFormDto dto);
        Task<bool> DeleteAsync(Guid id);

    }
}