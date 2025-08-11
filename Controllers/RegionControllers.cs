using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MigrationApi.Controllers
{

    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegionController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var regions = await _context.Regions
            .Select(r => new RegionDto
            {
                Name = r.Name,

            }).ToListAsync();

            return Ok(regions);


        }


        [HttpGet("{id}")]
        public IActionResult GetRegionById(int id)
        {
            var region = _context.Regions
                .Where(r => r.Id == id)
                .Select(r => new RegionDto
                {
                    Name = r.Name,
                    District = r.District.Select(d => new DistrictDto
                    {
                        Name = d.Name
                    }).ToList()
                })
                .FirstOrDefault();

            if (region == null)
                return NotFound();

            return Ok(region);
        }



        [HttpPost]
        public IActionResult Create([FromBody] CreateRegionDto regionDto)
        {
            var newregion = new Region
            {
                Name = regionDto.Name
            };

            _context.Regions.Add(newregion);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRegionById), new { Id = newregion.Id }, newregion);
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateRegionDto regionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var region = _context.Regions
            .FirstOrDefault(r => r.Id == id);

            if (region == null)
                return NotFound(); ;

            if (!_context.Regions.Any(r => r.Id == regionDto.RegionId))
                return BadRequest("Invalid StatusId");

            region.Name = regionDto.Name;
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var region = _context.Regions.Find(id);
            if (region == null)
                return NotFound();

            _context.Regions.Remove(region);
            _context.SaveChanges();

            return NoContent();
        }


    }
}