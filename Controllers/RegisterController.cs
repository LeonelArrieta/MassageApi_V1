using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using MassageApi_V1.Services;
using Microsoft.AspNetCore.Mvc;

namespace MassageApi_V1.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IUserService _userService;

        public RegisterController(MyDBContext context, IUserService _userService)
        {
            _context = context;
            this._userService = _userService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserNewDTO user)
        {
            if (user.Email == "" || user.Password == "")
                return BadRequest("Usuario y/o contraseña incorrectos");
            var hashUser = new User();
            hashUser.Email = user.Email;
            hashUser.Password = _userService.EncryptPassword(user.Password);
            await _context.Users.AddAsync(hashUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
