using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{
    [Route("api/migration_status")]
    [ApiController]
    public class MigrationStatusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MigrationStatusController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllMigrationStatuses()
        {
            if (!ModelState.IsValid)
        return BadRequest(ModelState);
            var migrationstatuses = _context.MigrationStatuses
                .Select(c => new MigrationStatusDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return Ok(migrationstatuses);
        }


        [HttpGet("{id}")]
        public IActionResult GetMigrationStatusById(int id)
        {
            

            var migrationstatuses = _context.MigrationStatuses
                .Where(c => c.Id == id)
                .Select(c => new MigrationStatusDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();

            if (migrationstatuses == null)
                return NotFound();

            return Ok(migrationstatuses);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] MigrationStatusDto migrationstatusDto)
        {
            
            
            var newmigrationstatus = new MigrationStatus
            {
                Name = migrationstatusDto.Name
                
            };

            _context.MigrationStatuses.Add(newmigrationstatus);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMigrationStatusById), new { Id = newmigrationstatus.Id }, newmigrationstatus);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MigrationStatusDto migrationstatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var migrationstatuses = _context.MigrationStatuses
            .FirstOrDefault(c => c.Id == id);

            if (migrationstatuses == null)
                return NotFound(); ;

            

            migrationstatuses.Name = migrationstatusDto.Name;
            
            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var migrationstatuses = _context.MigrationStatuses.Find(id);
            if (migrationstatuses == null)
                return NotFound();

            _context.MigrationStatuses.Remove(migrationstatuses);
            _context.SaveChanges();

            return NoContent();
        }
    }
}