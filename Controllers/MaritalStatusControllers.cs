using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{
    [Route("api/marital_status")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaritalStatusController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllMaritalStatuses()
        {
            if (!ModelState.IsValid)
        return BadRequest(ModelState);
            var maritalstatuses = _context.MaritalStatuses
                .Select(c => new MaritalStatusDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return Ok(maritalstatuses);
        }


        [HttpGet("{id}")]
        public IActionResult GetMaritalStatusById(int id)
        {
            

            var maritalstatus = _context.MaritalStatuses
                .Where(c => c.Id == id)
                .Select(c => new MaritalStatusDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();

            if (maritalstatus == null)
                return NotFound();

            return Ok(maritalstatus);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] MaritalStatusDto maritalstatusDto)
        {
            
            
            var newmaritalstatus = new MaritalStatus
            {
                Name = maritalstatusDto.Name
                
            };

            _context.MaritalStatuses.Add(newmaritalstatus);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMaritalStatusById), new { Id = newmaritalstatus.Id }, newmaritalstatus);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MaritalStatusDto maritalstatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var maritalstatus = _context.MaritalStatuses
            .FirstOrDefault(c => c.Id == id);

            if (maritalstatus == null)
                return NotFound(); ;

            

            maritalstatus.Name = maritalstatusDto.Name;
            
            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var maritalstatus = _context.MaritalStatuses.Find(id);
            if (maritalstatus == null)
                return NotFound();

            _context.MaritalStatuses.Remove(maritalstatus);
            _context.SaveChanges();

            return NoContent();
        }
    }
}