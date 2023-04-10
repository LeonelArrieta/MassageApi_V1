using MassageApi_V1.Models;
using MassageApi_V1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IUserService _userService;

        public LoginController(MyDBContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
       
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            var userAuthenticate = await _context.Users.Where(x => x.Email == user.Email && x.Password == _userService.EncryptPassword(user.Password)).FirstOrDefaultAsync();
            if(userAuthenticate is not null)
            {
                var token = _userService.GenerateToken(user);
                return Ok(token);
            }
            return BadRequest("Usuario y/o contraseña incorrectos");
        }
    }
}
