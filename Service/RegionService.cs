using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _repo;

        public RegionService(IRegionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<RegionDto>> GetAllAsync()
        {
            var region = await _repo.GetAllAsync();
            return region.Select(r => new RegionDto
            {
                Name = r.Name,

            }).ToList();
        }

        public async Task<RegionDto?> GetByIdAsync(int id)
        {
            var region = await _repo.GetByIdAsync(id);
            if (region == null) return null;
            return new RegionDto
            {
                Name = region.Name,
                District = region.District.Select(d => new DistrictDto
                {
                    Name = d.Name
                }).ToList()
            };
        }

        public async Task<Region> CreateAsync(CreateRegionDto dto)
        {
            var newregion = new Region
            {
                Name = dto.Name
            };
            await _repo.AddAsync(newregion);
            await _repo.SaveAsync();
            return newregion;
        }

        public async Task<bool> UpdateAsync(int id, CreateRegionDto dto)
        {
            var region = await _repo.GetByIdAsync(id);
            if (region == null) return false;
            region.Name = dto.Name;
            await _repo.AddAsync(region);
            await _repo.SaveAsync();
            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var region = await _repo.GetByIdAsync(id);
            if (region == null) return false;
            await _repo.DeleteAsync(region);
            await _repo.SaveAsync();
            return true;
        }

    }
}