using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationApi.Dto;
using MigrationApi.Interfaces;
using MigrationApi.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MigrationApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {

                UserName = registerUserDto.UserName,
                
                Email = registerUserDto.Email,
                RoleID = registerUserDto.RoleID
            };

            var createdUser = await _userManager.CreateAsync(user, registerUserDto.Password);
            if (!createdUser.Succeeded)
                return BadRequest(createdUser.Errors);
            return Ok("user created successfully");



        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users
            .Include(x=>x.Role)
            .FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null) return Unauthorized("Invalid Username!");


            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Password is incorrect");

            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                RoleName = user.Role.Name,
                Token = _tokenService.CreateToken(user)

            });
        }
    }
}