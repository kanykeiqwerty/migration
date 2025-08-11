using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            if (!ModelState.IsValid)
        return BadRequest(ModelState);
            var countries = _context.Countries
                .Select(c => new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return Ok(countries);
        }


        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            

            var country = _context.Countries
                .Where(c => c.Id == id)
                .Select(c => new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] CountryDto countryDto)
        {
            
            
            var newcountry = new Country
            {
                Name = countryDto.Name
                
            };

            _context.Countries.Add(newcountry);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCountryById), new { Id = newcountry.Id }, newcountry);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var country = _context.Countries
            .FirstOrDefault(c => c.Id == id);

            if (country == null)
                return NotFound(); ;

            

            country.Name = countryDto.Name;
            
            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
                return NotFound();

            _context.Countries.Remove(country);
            _context.SaveChanges();

            return NoContent();
        }
    }
}