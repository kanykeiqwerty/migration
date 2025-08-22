using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{
    [Route("api/migration_status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllStatuses()
        {
            if (!ModelState.IsValid)
        return BadRequest(ModelState);
            var statuses = _context.Statuses
                .Select(c => new StatusDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return Ok(statuses);
        }


        [HttpGet("{id}")]
        public IActionResult GetStatusById(int id)
        {
            

            var statuses = _context.Statuses
                .Where(c => c.Id == id)
                .Select(c => new StatusDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();

            if (statuses == null)
                return NotFound();

            return Ok(statuses);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] StatusDto statusDto)
        {
            
            
            var newstatus = new Status
            {
                Name = statusDto.Name
                
            };

            _context.Statuses.Add(newstatus);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStatusById), new { Id = newstatus.Id }, newstatus);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StatusDto statusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var statuses = _context.Statuses
            .FirstOrDefault(c => c.Id == id);

            if (statuses == null)
                return NotFound(); ;

            

            statuses.Name = statusDto.Name;
            
            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var statuses = _context.Statuses.Find(id);
            if (statuses == null)
                return NotFound();

            _context.Statuses.Remove(statuses);
            _context.SaveChanges();

            return NoContent();
        }
    }
}