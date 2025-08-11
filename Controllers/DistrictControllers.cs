using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{

    [ApiController]
    [Route("api/districts")]
    public class DistrictController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DistrictController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllDistricts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var regions = await _context.Districts
            .Include(d => d.Region)
            .Select(d => new DistrictDto
            {
                Name = d.Name,
                Region = d.Region == null ? null : new CreateRegionDto
                {
                    Name = d.Region.Name
                }


            }).ToListAsync();

            return Ok(regions);


        }


        [HttpGet("{id}")]
        public IActionResult GetDistrictById(int id)
        {
            var region = _context.Districts
                .Where(d => d.Id == id)
                .Select(d => new DistrictDto
                {
                    Name = d.Name,
                    Region = d.Region == null ? null : new CreateRegionDto
                    {
                        RegionId=d.Region.Id,
                        Name = d.Region.Name
                    }
                })
                .FirstOrDefault();

            if (region == null)
                return NotFound();

            return Ok(region);
        }



        [HttpPost]
        public IActionResult Create([FromBody] CreateDistrictDto districtDto)
        {


            if (!_context.Regions.Any(s => s.Id == districtDto.RegionId))
                return BadRequest("Invalid RegionId");
            var newdistrict = new District
            {
                Name = districtDto.Name,
                RegionId = districtDto.RegionId,
            };

            _context.Districts.Add(newdistrict);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDistrictById), new { Id = newdistrict.Id }, newdistrict);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateDistrictDto districtDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var district = _context.Districts
            .Include(d => d.Region)
            .FirstOrDefault(d => d.Id == id);

            if (district == null)
                return NotFound(); ;

            if (!_context.Regions.Any(r => r.Id == districtDto.RegionId))
                return BadRequest("Invalid RegionId");

            district.Name = districtDto.Name;
            district.RegionId = districtDto.RegionId;
            _context.SaveChanges();
            return NoContent();

        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var district = _context.Districts.Find(id);
            if (district == null)
                return NotFound();

            _context.Districts.Remove(district);
            _context.SaveChanges();

            return NoContent();
        }



    }
}
