using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface ICitizenFormService
    {
        Task<List<CitizenFormDto>> GetAllAsync(CitizenFormFilterDto filter);
        Task<List<CitizenFormDto>> GetAllActiveAsync();
        Task<List<CitizenFormDto>> GetAllArchivedAsync();
        
        Task<OneCitizenFormDto?> GetByIdAsync(Guid id);
        
        Task<OneCitizenFormDto?> GetByPINAsync(string PIN);
        Task<CitizenForm> CreateAsync(CreateCitizenFormDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateCitizenFormDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UnarchiveAsync(Guid id);
        Task<bool> ArchiveAsync(Guid id);
    }
}