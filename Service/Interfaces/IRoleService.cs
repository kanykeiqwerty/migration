using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Service.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<Role> CreateAsync(RoleDto dto);
        Task<bool> UpdateAsync(int id, RoleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}