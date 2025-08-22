using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface IMaritalStatusService
    {
        Task<List<MaritalStatusDto>> GetAllAsync();
        Task<MaritalStatusDto?> GetByIdAsync(int id);
        Task<MaritalStatus> CreateAsync(MaritalStatusDto dto);
        Task<bool> UpdateAsync(int id, MaritalStatusDto dto);
        Task<bool> DeleteAsync(int id);
    }
}