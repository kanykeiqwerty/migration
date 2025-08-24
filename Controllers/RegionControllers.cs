using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _service;

        public RegionController(IRegionService service)
        {
            _service=service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var region = await _service.GetAllAsync();
            return Ok(region);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var region = await _service.GetByIdAsync(id);
            if (region == null) return NotFound();
            return Ok(region);
       }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto dto)
        {
            var region = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateRegionDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}