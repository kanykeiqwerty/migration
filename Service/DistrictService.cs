using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _repo;

        public DistrictService(IDistrictRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<DistrictDto>> GetAllAsync()
        {
            var districts = await _repo.GetAllAsync();
            return districts.Select(d => new DistrictDto
            {
                Name = d.Name,
                Region = d.Region == null ? null : new CreateRegionDto
                {
                    Name = d.Region.Name
                }


            }).ToList();
        }


        public async Task<DistrictDto?> GetByIdAsync(int id)
        {
            var d = await _repo.GetByIdAsync(id);
            if (d == null) return null;

            return new DistrictDto
            {
                Name = d.Name,
                Region = d.Region == null ? null : new CreateRegionDto
                {
                    RegionId = d.Region.Id,
                    Name = d.Region.Name
                }
            };
        }

        public async Task<District> CreateAsync(CreateDistrictDto dto)
        {
            if (!await _repo.RegionExistsAsync(dto.RegionId))
                throw new ArgumentException("Invalid DistrictId");


            var newdistrict = new District
            {
                Name = dto.Name,
                RegionId = dto.RegionId
            };

            await _repo.AddAsync(newdistrict);
            await _repo.SaveAsync();
            return newdistrict;


        }

        public async Task<bool> UpdateAsync(int id, CreateDistrictDto dto)
        {
            var district = await _repo.GetByIdAsync(id);
            if (district == null) return false;
            if (!await _repo.RegionExistsAsync(dto.RegionId))
                throw new ArgumentException("Invalid DistrictId");

            district.Name = dto.Name;
            district.RegionId = dto.RegionId;

            await _repo.UpdateAsync(district);
            await _repo.SaveAsync();
            return true;


        }

        public async Task<bool> DeleteAsync(int id)
        {
            var district = await _repo.GetByIdAsync(id);
            if (district == null) return false;

            await _repo.DeleteAsync(district);
            await _repo.SaveAsync();
            return true;
        }
    }
}