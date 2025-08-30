using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Controllers
{
    [Route("api/migration_history")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private readonly IMigrationService _service;

        public MigrationController(IMigrationService service)
        {
            _service=service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var migration = await _service.GetAllAsync();
            return Ok(migration);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var migration = await _service.GetByIdAsync(id);
            if (migration == null) return NotFound();
            return Ok(migration);
       }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MigrationOneDto dto)
        {
            var migration = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = migration.Id }, migration);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMigrationDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}