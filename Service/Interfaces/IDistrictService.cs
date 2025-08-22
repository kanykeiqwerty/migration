using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface IDistrictService
    {
        Task<List<DistrictDto>> GetAllAsync();
        Task<DistrictDto?> GetByIdAsync(int id);
        Task<District> CreateAsync(CreateDistrictDto dto);
        Task<bool> UpdateAsync(int id, CreateDistrictDto dto);
        Task<bool> DeleteAsync(int id);
    }
}