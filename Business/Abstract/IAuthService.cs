using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterRequest registerRequest);
        Task<string> Login(LoginRequest loginRequest);
    }
}