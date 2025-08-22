using Microsoft.AspNetCore.Mvc;
using MigrationApi.Data;
using MigrationApi.Dto;
using MigrationApi.Models;

namespace MigrationApi.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoleController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            if (!ModelState.IsValid)
        return BadRequest(ModelState);
            var roles = _context.Roles
                .Select(c => new RoleDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return Ok(roles);
        }


        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            

            var role = _context.Roles
                .Where(c => c.Id == id)
                .Select(c => new RoleDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();

            if (role == null)
                return NotFound();

            return Ok(role);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] RoleDto roleDto)
        {
            
            
            var newrole = new Role
            {
                Name = roleDto.Name
                
            };

            _context.Roles.Add(newrole);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRoleById), new { Id = newrole.Id }, newrole);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var role = _context.Roles
            .FirstOrDefault(c => c.Id == id);

            if (role == null)
                return NotFound(); ;

            

            role.Name = roleDto.Name;
            
            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
                return NotFound();

            _context.Roles.Remove(role);
            _context.SaveChanges();

            return NoContent();
        }
    }
}