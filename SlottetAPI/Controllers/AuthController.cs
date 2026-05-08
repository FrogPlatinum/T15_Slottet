using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs;

namespace Slottet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //[HttpPost("register")]
        //public ActionResult<User> Register(UserDto dto)
        //{
        //    var hashedPassword = new PasswordHasher<User>()
        //        .HashPassword(user, dto.Password);
        //}
    }
}
