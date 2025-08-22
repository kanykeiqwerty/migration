using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Controllers
{

    [ApiController]
    [Route("api/districts")]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _service;

        public DistrictController(IDistrictService service)
        {
            _service = service;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllDistricts()
        {
            var districts = await _service.GetAllAsync();

            return Ok(districts);


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var district = await _service.GetByIdAsync(id);
            if (district == null) return NotFound();
            return Ok(district);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDistrictDto dto)
        {
            var district = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = district.Id }, district);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDistrictDto dto)
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
