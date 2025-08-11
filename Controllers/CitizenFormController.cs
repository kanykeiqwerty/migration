using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{
    [ApiController]
    [Route("api/citizen_forms")]
    public class CitizenFormController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CitizenFormController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllForms()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var forms = await _context.CitizenForms
            .Include(f => f.District)
            .ThenInclude(d => d.Region)
            .Include(f => f.Migrations)
            .ThenInclude(m => m.Country)

            .Select(f => new CitizenFormDto
            {
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
            }).ToListAsync();

            return Ok(forms);



        }




        [HttpGet("{id}")]
        public IActionResult GetCitizenFormById(int id)
        {

            var form = _context.CitizenForms
            .Include(f => f.District)
            .ThenInclude(d => d.Region)
            .Include(f => f.Migrations)
            .ThenInclude(m => m.Country)

            .Select(f => new OneCitizenFormDto
            {
                RegistrationDate = f.RegistrationDate,
                Id = f.Id,
                ESYBMId = f.ESYBMId,
                ENIcode = f.ENIcode,
                PIN = f.PIN,
                FirstName=f.FirstName,
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

                Migrations = f.Migrations.Select(m => new MigrationHistoryDto
                {

                    DepartureDate = m.DepartureDate,
                    ReturnDate = m.ReturnDate,
                    Profession = m.Profession,
                    EmploymentContract = m.EmploymentContract,
                    CountryName = m.Country.Name



                }).ToList()




            }).FirstOrDefault();

            return Ok(form);
        }



        [HttpPost]
        public IActionResult Create([FromBody] CreateCitizenFormDto formDto)
        {
            if (!_context.Districts.Any(d => d.Id == formDto.DistrictId))
                return BadRequest("Invalid DistrictId");

            // if (!_context.Regions.Any(r => r.Id == formDto.RegionId))
            //     return BadRequest("Invalid RegionId");

            if (!_context.MaritalStatuses.Any(m => m.Id == formDto.MaritalStatusId))
                return BadRequest("Invalid Marital Status Id");

            var newform = new CitizenForm
            {
                PIN = formDto.PIN,
                BirthDate = formDto.BirthDate,
                Gender = formDto.Gender,
                FirstName = formDto.FirstName,
                LastName = formDto.LastName,
                MidName = formDto.MidName,
                Disabilities = formDto.Disabilities,
                PhoneNumber = formDto.PhoneNumber,
                ESYBMId = formDto.ESYBMId,
                ENIcode = formDto.ENIcode,
                RuralArea = formDto.RuralArea,
                PopulationArea = formDto.PopulationArea,
                Street = formDto.Street,
                House = formDto.House,
                Apartments = formDto.Apartments,
                DistrictID = formDto.DistrictId,
                MaritalStatusID = formDto.MaritalStatusId




            };
            _context.CitizenForms.Add(newform);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCitizenFormById), new { id = newform.Id }, newform);
        }
    }
}

    
