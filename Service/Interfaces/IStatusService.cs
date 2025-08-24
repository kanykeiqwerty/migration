using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface IStatusService
    {
        Task<List<StatusDto>> GetAllAsync();
        Task<StatusDto?> GetByIdAsync(int id);
        Task<Status> CreateAsync(StatusDto dto);
        Task<bool> UpdateAsync(int id, StatusDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
