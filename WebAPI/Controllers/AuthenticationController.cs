using System;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete.Authentication;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = UserRoles.Admin)]
        [Authorize]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var result = await _authService.Register(registerRequest);
            return result.Succeeded
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
        public async Task<string> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.Login(loginRequest);

            if (result != null) return result;
            throw new Exception("Failed login");
        }
    }
}