using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs;

namespace Slottet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto dto)
        {
            var user = await authService.RegisterAsync(dto);
            if (user  == null)
            {
                return BadRequest("Bruger findes allerede");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto dto)
        {
            var token = await authService.LoginAsync(dto);
            if (token == null)
            {
                return BadRequest("Brugernavn eller kode er forkert");
            }
            return Ok(token);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveUser(int id)
        {
            await authService.RemoveUserAsync(id);
            return Ok("Bruger slettet");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AuthTest()
        {
            return Ok("Authenticated!");
        }
    }
}
