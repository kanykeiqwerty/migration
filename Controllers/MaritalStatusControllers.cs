using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Controllers
{
    [Route("api/marital_status")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IMaritalStatusService _service;

        public MaritalStatusController(IMaritalStatusService service)
        {
            _service=service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var maritals = await _service.GetAllAsync();
            return Ok(maritals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var maritalStatus = await _service.GetByIdAsync(id);
            if (maritalStatus == null) return NotFound();
            return Ok(maritalStatus);
       }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaritalStatusDto dto)
        {
            var maritalStatus = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = maritalStatus.Id }, maritalStatus);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaritalStatusDto dto)
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