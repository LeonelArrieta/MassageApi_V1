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
            switch (response.Success)
            {
                case true:
                    return Ok(response.Message);
                case false:
                    return BadRequest(response.Message);
                default:
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, "Error inesperado.");
            }
        }
    }
}
