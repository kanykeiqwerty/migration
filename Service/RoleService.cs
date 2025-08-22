using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;
        public RoleService(IRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var role = await _repo.GetAllAsync();
            return role.Select(c => new RoleDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var role = await _repo.GetByIdAsync(id);

            if (role == null) return null;

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public async Task<Role> CreateAsync(RoleDto dto)
        {
            var newrole = new Role
            {
                Name = dto.Name
            };

            await _repo.AddAsync(newrole);
            await _repo.SaveAsync();
            return newrole;
        }

        public async Task<bool> UpdateAsync(int id, RoleDto dto)
        {
            var role = await _repo.GetByIdAsync(id);
            if (role == null) return false;

            role.Name = dto.Name;

            await _repo.UpdateAsync(role);
            await _repo.SaveAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _repo.GetByIdAsync(id);
            if (role == null) return false;

            await _repo.DeleteAsync(role);
            await _repo.SaveAsync();
            return true;
        }
    }
}