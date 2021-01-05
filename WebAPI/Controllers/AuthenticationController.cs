using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            return _authService.Register(registerRequest).Result.Succeeded
                ? Ok(new Response
                {
                    Status = "Success",
                    Message = "User created successfully"
                })
                : StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "User creation failed"
                });
        }

        [HttpPost]
        [Route("login")]
        public async Task<Task<string>> Login([FromBody] LoginRequest loginRequest)
        {
            return _authService.Login(loginRequest);
        }
    }
}