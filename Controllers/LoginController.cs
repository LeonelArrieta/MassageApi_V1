using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using MassageApi_V1.Services;
using Microsoft.AspNetCore.Mvc;

namespace MassageApi_V1.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(MyDBContext context, IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserNewDTO user)
        {
            var response = await _userService.Login(user);
            if (response.ToString() == System.Net.HttpStatusCode.BadRequest.ToString())
                return BadRequest("Usuario y / o contraseña incorrectos");
            return Ok(response);
        }
    }
}
