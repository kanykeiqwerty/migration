using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface IRegionService
    {
        Task<List<RegionDto>> GetAllAsync();
        Task<RegionDto?> GetByIdAsync(int id);
        Task<Region> CreateAsync(CreateRegionDto dto);
        Task<bool> UpdateAsync(int id, CreateRegionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}