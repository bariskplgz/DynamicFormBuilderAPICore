using DynamicFormBuilder.Core.Dtos;
using DynamicFormBuilder.Core.Responses;
using DynamicFormBuilder.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DynamicFormBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ApiResponse<string>> Login([FromBody] UserLoginDto loginDto)
        {
            ApiResponse<string> response = new();

            var user = await _authService.LoginAsync(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Invalid username or password";
                return response;
            }
            else
            {
                var token = _authService.GenerateJWT(user.Username);
                response.Data = token;
                return response;    
            }
        }
    }
}
