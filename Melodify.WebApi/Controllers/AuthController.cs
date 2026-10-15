using Melodify.BusinessLayer.Abstract;
using Melodify.DtoLayer.AuthDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
