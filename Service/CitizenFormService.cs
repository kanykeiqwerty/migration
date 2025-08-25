using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Repositories.Interfaces;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Service
{
    public class CitizenFormService : ICitizenFormService
    {
        private readonly ICitizenFormRepository _repo;
        private readonly ICurrentUserService _currentUserService;

        public CitizenFormService(ICitizenFormRepository repo, ICurrentUserService currentUserService)
        {
            _repo = repo;
            _currentUserService = currentUserService;
        }

        public async Task<List<CitizenFormDto>> GetAllAsync()
        {
            var forms = await _repo.GetAllAsync();
            return forms.Select(f => new CitizenFormDto
            {
                Id=f.Id,
                RegistrationDate = f.RegistrationDate,
                PIN = f.PIN,
                FullName = f.FullName,
                BirthDate = f.BirthDate,
                Gender = f.Gender,
                District = f.District == null ? null : new DistrictDto
                {
                    Name = f.District.Name,
                    Region = f.District.Region == null ? null : new CreateRegionDto
                    {
                        Name = f.District.Region.Name
                    }
                },
                Migrations = f.Migrations
                    .OrderByDescending(m => m.DepartureDate)
                    .Take(1)
                    .Select(m => new MigrationDto
                    {
                        CountryName = m.Country.Name,
                        DepartureDate = m.DepartureDate
                    }).ToList()
            }).ToList();
        }

        public async Task<OneCitizenFormDto?> GetByIdAsync(Guid id)
        {
            var f = await _repo.GetByIdAsync(id);
            if (f == null) return null;

            return new OneCitizenFormDto
            {
                IsArchived = f.IsArchived,
                RegistrationDate = f.RegistrationDate,
                Id = f.Id,
                ESYBMId = f.ESYBMId,
                ENIcode = f.ENIcode,
                PIN = f.PIN,
                FirstName = f.FirstName,
                LastName = f.LastName,
                MidName = f.MidName,
                BirthDate = f.BirthDate,
                Gender = f.Gender,
                Disabilities = f.Disabilities,
                PhoneNumber = f.PhoneNumber,
                RuralArea = f.RuralArea,
                PopulationArea = f.PopulationArea,
                Street = f.Street,
                House = f.House,
                Apartments = f.Apartments,

                District = f.District == null ? null : new DistrictDto
                {
                    Name = f.District.Name,
                    Region = f.District.Region == null ? null : new CreateRegionDto
                    {
                        Name = f.District.Region.Name
                    }
                },
                MaritalStatus = f.MaritalStatus == null ? null : new MaritalStatusDto
                {
                    Name = f.MaritalStatus.Name
                },
                Status = f.Status == null ? null : new StatusDto
                {
                    Name = f.Status.Name
                },

                Migrations = f.Migrations.Select(m => new MigrationHistoryDto
                {
                    DepartureDate = m.DepartureDate,
                    ReturnDate = m.ReturnDate,
                    Profession = m.Profession,
                    EmploymentContract = m.EmploymentContract,
                    CountryName = m.Country.Name
                }).ToList(),
                CreatedByUserName = f.CreatedByUser?.UserName,
                UpdatedByUserName = f.UpdatedByUser?.UserName,  // <-- имя обновившего
                CreatedAt = f.Created_at, 
                UpdatedAt = f.Updated_at
    
            };
        }

        public async Task<CitizenForm> CreateAsync(CreateCitizenFormDto dto)
        {
            if (!await _repo.DistrictExistsAsync(dto.DistrictId))
                throw new ArgumentException("Invalid DistrictId");

            if (!await _repo.MaritalStatusExistsAsync(dto.MaritalStatusId))
                throw new ArgumentException("Invalid Marital Status Id");

                var userId = _currentUserService.UserId ?? throw new Exception("User not authenticated");
                

            var newform = new CitizenForm
            {
                PIN = dto.PIN,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MidName = dto.MidName,
                Disabilities = dto.Disabilities,
                PhoneNumber = dto.PhoneNumber,
                ESYBMId = dto.ESYBMId,
                ENIcode = dto.ENIcode,
                RuralArea = dto.RuralArea,
                PopulationArea = dto.PopulationArea,
                Street = dto.Street,
                House = dto.House,
                Apartments = dto.Apartments,
                DistrictID = dto.DistrictId,
                MaritalStatusID = dto.MaritalStatusId,
                StatusID = dto.StatusId,
                Created_at = DateTime.UtcNow,
                CreatedByUserID = userId
                
            };

            await _repo.AddAsync(newform);
            await _repo.SaveAsync();
            return newform;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateCitizenFormDto dto)
        {

            var userId = _currentUserService.UserId ?? throw new Exception("User not authenticated");
            var form = await _repo.GetByIdAsync(id);
            if (form == null) return false;

            if (!await _repo.DistrictExistsAsync(dto.DistrictId))
                throw new ArgumentException("Invalid DistrictId");

            if (!await _repo.StatusExistsAsync(dto.StatusId))
                throw new ArgumentException("Invalid Status Id");

            if (!await _repo.MaritalStatusExistsAsync(dto.MaritalStatusId))
                throw new ArgumentException("Invalid Marital Status Id");

            form.BirthDate = dto.BirthDate;
            form.Gender = dto.Gender;
            form.FirstName = dto.FirstName;
            form.LastName = dto.LastName;
            form.MidName = dto.MidName;
            form.Disabilities = dto.Disabilities;
            form.PhoneNumber = dto.PhoneNumber;
            form.RuralArea = dto.RuralArea;
            form.PopulationArea = dto.PopulationArea;
            form.Street = dto.Street;
            form.House = dto.House;
            form.Apartments = dto.Apartments;
            form.DistrictID = dto.DistrictId;
            form.MaritalStatusID = dto.MaritalStatusId;
            form.StatusID = dto.StatusId;
            form.UpdatedByUserID = userId;
            form.Updated_at = DateTime.UtcNow;
            

            form.IsArchived = dto.IsArchived;
            
            await _repo.UpdateAsync(form);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var form = await _repo.GetByIdAsync(id);
            if (form == null) return false;

            await _repo.DeleteAsync(form);
            await _repo.SaveAsync();
            return true;
        }
    }
}

