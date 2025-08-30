using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAll([FromQuery] CitizenFormFilterDto filter)
    {

        
        var forms = await _service.GetAllAsync(filter);
        return Ok(forms);
    }

//         [HttpGet("filter")]
// public async Task<IActionResult> GetFiltered([FromQuery] CitizenFormFilterDto filter)
// {
//     var result = await _service.GetAllAsync(filter);
//     return Ok(result);
// }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var forms = await _service.GetAllActiveAsync();
            return Ok(forms);
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchived()
        {
            var forms = await _service.GetAllArchivedAsync();
            return Ok(forms);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var form = await _service.GetByIdAsync(id);
            if (form == null) return NotFound();
            return Ok(form);
        }

        

        [HttpGet("PIN")]
        public async Task<IActionResult> GetByPIN(string PIN)
        {
            var form = await _service.GetByPINAsync(PIN);
            if (form == null) return NotFound();
            return Ok(form);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCitizenFormDto dto)
        {
            var form = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = form.Id }, form);
        }
        [Authorize]
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

        [HttpPost("{id}/unarchive")]
        public async Task<IActionResult> UnArchive(Guid id)
        {
            var success = await _service.UnarchiveAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/archive")]
        public async Task<IActionResult> Archive(Guid id)
        {
            var success = await _service.ArchiveAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

    
