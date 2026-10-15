using Melodify.BusinessLayer.Abstract;
using Melodify.DataAccessLayer.Abstract;
using Melodify.DataAccessLayer.Concrete;
using Melodify.DtoLayer.AuthDtos;
using Melodify.EntityLayer.Entities;
using Melodify.EntityLayer.Enums;
using Microsoft.AspNetCore.Identity;

namespace Melodify.BusinessLayer.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepository<Package> _genericRepository;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<AppUser> userManager, IGenericRepository<Package> genericRepository, IJwtService jwtService)
        {
            _userManager = userManager;
            _genericRepository = genericRepository;
            _jwtService = jwtService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user is null)
            {
                return null;
            }

            var password = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if(!password)
            {
                return null;
            }

           var token =  await _jwtService.GenerateTokenAsync(user);
           return token;
           

        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var emailExist = await _userManager.FindByEmailAsync(registerDto.Email);

            if (emailExist != null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "DuplicateEmail",
                    Description = "Bu e-posta zaten kullanılmaktadır."
                });
            }

            var userExist = await _userManager.FindByNameAsync(registerDto.UserName);

            if(userExist != null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "DuplicateUserName",
                    Description="Bu kullanıcı adı zaten kullanılmaktadır."
                });

            }

            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "PasswordMismatch",
                    Description = "Şifreler Uyuşmuyor!"
                });

            }


            var packages = await _genericRepository.GetAllAsync();

            var freePackage = packages.FirstOrDefault
                (p => p.Level == PackageLevel.Free && p.IsActive);
           
            if(freePackage ==null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "FreePackageNotFound",
                    Description = "Aktif Free paketi bulunamadı."
                });
            }
            var user = new AppUser
            {
                Name = registerDto.Name,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Surname = registerDto.Surname,
                PackageId=freePackage.PackageId,
                PackageStartDate=DateTime.UtcNow
                
            };

            var newUser = await _userManager.CreateAsync(user, registerDto.Password);

            if(!newUser.Succeeded)
            {
                return newUser;
            }

            return IdentityResult.Success;

        }
    }
}
