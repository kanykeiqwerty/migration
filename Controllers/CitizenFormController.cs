using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;
using MigrationApi.Service.Interfaces;

namespace MigrationApi.Controllers
{
    [ApiController]
    [Route("api/citizen_forms")]
    public class CitizenFormController : ControllerBase
    {
        
        private readonly ICitizenFormService _service;

        public CitizenFormController(ICitizenFormService service)
        {
          
            _service = service;
        }

        


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var forms = await _service.GetAllAsync();
            return Ok(forms);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var form = await _service.GetByIdAsync(id);
            if (form == null) return NotFound();
            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCitizenFormDto dto)
        {
            var form = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = form.Id }, form);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCitizenFormDto dto)
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

    
