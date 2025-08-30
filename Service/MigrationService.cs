using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class MigrationService : IMigrationService
    {
        private readonly IMigrationRepository _repo;
        public MigrationService(IMigrationRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MigrationHistoryDto>> GetAllAsync()
        {
            var migrations = await _repo.GetAllAsync();
            return migrations.Select(m => new MigrationHistoryDto
            {
                Id = m.Id,
                DepartureDate = m.DepartureDate,
                ReturnDate = m.ReturnDate,
                CountryName = m.Country.Name,
                Profession = m.Profession,
                EmploymentContract = m.EmploymentContract

            }).ToList();


        }

        public async Task<MigrationHistoryDto?> GetByIdAsync(Guid id)
        {
            var m = await _repo.GetByIdAsync(id);
            if (m == null) return null;
            return new MigrationHistoryDto
            {
                Id = m.Id,
                DepartureDate = m.DepartureDate,
                ReturnDate = m.ReturnDate,
                CountryName = m.Country.Name,
                Profession = m.Profession,
                EmploymentContract = m.EmploymentContract

            };
        }

        public async Task<Migration> CreateAsync(MigrationOneDto dto)
        {
            if (!await _repo.CountryExistsAsync(dto.CountryId))
                throw new ArgumentException("Invalid CountryID");

            var newmigration = new Migration
            {
                CitizenFormID = dto.CitizenFormID,
                DepartureDate = dto.DepartureDate,
                ReturnDate = dto.ReturnDate,
                CountryID = dto.CountryId,
                Profession = dto.Profession,
                EmploymentContract = dto.EmploymentContract
            };
            
             await _repo.AddAsync(newmigration);

            if (dto.ReturnDate != null)
            {
                var citizenForm = await _repo.GetCitizenFormByIdAsync(dto.CitizenFormID);
                if (citizenForm != null)
                {
                    citizenForm.IsArchived = true;
                    await _repo.UpdateCitizenFormAsync(citizenForm);
                }
            }
           
            await _repo.SaveAsync();
            return newmigration;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateMigrationDto dto)
        {

            var migration = await _repo.GetByIdAsync(id);
            if (migration == null) return false;

            if (!await _repo.CountryExistsAsync(dto.CountryId))
                throw new ArgumentException("Invalid CountryID");



            migration.DepartureDate = dto.DepartureDate;
            migration.ReturnDate = dto.ReturnDate;
            migration.CountryID = dto.CountryId;
            migration.Profession = dto.Profession;
            migration.EmploymentContract = dto.EmploymentContract;



            await _repo.UpdateAsync(migration);

            if (dto.ReturnDate != null)
            {
                var citizenForm = await _repo.GetCitizenFormByIdAsync(migration.CitizenFormID);
                if (citizenForm != null)
                {
                    citizenForm.IsArchived = true;
                    await _repo.UpdateCitizenFormAsync(citizenForm);
                }
            }
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var migration = await _repo.GetByIdAsync(id);
            if (migration == null) return false;

            await _repo.DeleteAsync(migration);
            await _repo.SaveAsync();
            return true;
        }
    }
}