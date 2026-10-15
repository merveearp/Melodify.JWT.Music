using Melodify.BusinessLayer.Abstract;
using Melodify.EntityLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Melodify.BusinessLayer.Concrete
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IPackageService _packageService;

        public JwtService(IConfiguration configuration, IPackageService packageService)
        {
            _configuration = configuration;
            _packageService = packageService;
        }

        public async Task<string> GenerateTokenAsync(AppUser appUser)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var userPackage = await _packageService.GetByIdAsync(appUser.PackageId);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,appUser.Id),
                new Claim(ClaimTypes.Name,appUser.UserName!),
                new Claim(ClaimTypes.Email,appUser.Email!),
                new Claim(ClaimTypes.Surname,appUser.Surname),

                new Claim("PackageId",appUser.PackageId.ToString()),
                new Claim("PackageName",userPackage.PackageName),
                new Claim("PackageLevel",userPackage.Level.ToString())

                
            };
         
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
            (

                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims:claims,
                notBefore:DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpireMinutes"]! )),
                signingCredentials:credentials
             );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
