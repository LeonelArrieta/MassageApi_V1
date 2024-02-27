using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using MassageApi_V1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MassageApi_V1.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserNewDTO user)
        {
            var response = await _userService.Register(user);
            if (response != HttpStatusCode.OK)
                return BadRequest(response);
            return Ok();
           

        }

    }
}
