using Azure.Core;
using Melodify.BusinessLayer.Abstract;
using Melodify.DtoLayer.AuthDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Melodify.WebApi.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await _authService.RegisterAsync(registerDto);
            if (!user.Succeeded)
            {
                return BadRequest(user.Errors);
            }
            return StatusCode(StatusCodes.Status201Created, new
            {
                Message = "Kullanıcı kaydı başarıyla oluşturuldu."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);

            if(token is null)
            {
                return Unauthorized("E-Posta veya Şifre Hatalı!");
            }

            return Ok(new {AccessToken=token});

        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                UserName = User.Identity?.Name
            });
        }
    }
}
