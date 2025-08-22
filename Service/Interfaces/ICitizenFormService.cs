using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface ICitizenFormService
    {
        Task<List<CitizenFormDto>> GetAllAsync();
        Task<OneCitizenFormDto?> GetByIdAsync(Guid id);
        Task<CitizenForm> CreateAsync(CreateCitizenFormDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateCitizenFormDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}