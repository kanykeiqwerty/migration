using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service=service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var country = await _service.GetAllAsync();
            return Ok(country);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _service.GetByIdAsync(id);
            if (country == null) return NotFound();
            return Ok(country);
       }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryDto dto)
        {
            var country = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = country.Id }, country);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CountryDto dto)
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