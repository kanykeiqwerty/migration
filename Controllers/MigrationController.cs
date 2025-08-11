using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{
    [ApiController]
    [Route("api/migrations")]
    public class MigrationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MigrationController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetAllMigrations()
        {
            var migrations = _context.Migrations
            .Include(m => m.CitizenForm)
            .Select(m => new MigrationHistoryDto
            {
                Id = m.Id,
                DepartureDate = m.DepartureDate,
                ReturnDate = m.ReturnDate,
                CountryName = m.Country.Name,
                Profession = m.Profession,
                EmploymentContract = m.EmploymentContract

            }).ToList();

            return Ok(migrations);
        }


        [HttpGet("{id}")]
        public IActionResult GetMigrationById(Guid id)
        {
            var migration = _context.Migrations
            .Where(m => m.Id == id)
            .Select(m => new MigrationHistoryDto
            {
                Id = m.Id,
                DepartureDate = m.DepartureDate,
                ReturnDate = m.ReturnDate,
                CountryName = m.Country.Name,
                Profession = m.Profession,
                EmploymentContract = m.EmploymentContract

            }).FirstOrDefault();

            if (migration == null)
                return NotFound();

            return Ok(migration);
        }

       [HttpPost("citizenforms/{citizenFormId}/migrations")]
public async Task<IActionResult> AddMigration(Guid citizenFormId, [FromBody] MigrationOneDto migrationDto)
{
    var citizenform = await _context.CitizenForms.FindAsync(citizenFormId);
    if (citizenform == null)
    {
        return NotFound("CitizenForm not found");
    }

    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var migration = new Migration
    {
        CitizenFormID = migrationDto.CitizenFormID,
        DepartureDate = migrationDto.DepartureDate,
        ReturnDate = migrationDto.ReturnDate,
        CountryID = migrationDto.CountryId,
        Profession = migrationDto.Profession,
        EmploymentContract = migrationDto.EmploymentContract
    };

    _context.Migrations.Add(migration);
    await _context.SaveChangesAsync();

    var resultDto = new MigrationHistoryDto
    {
        Id = migration.Id,
        DepartureDate = migration.DepartureDate,
        ReturnDate = migration.ReturnDate,
        CountryName = (await _context.Countries.FindAsync(migration.CountryID))?.Name,
        Profession = migration.Profession,
        EmploymentContract = migration.EmploymentContract
    };

    return CreatedAtAction(nameof(GetMigrationById), new { id = migration.Id }, resultDto);
}


    }
}