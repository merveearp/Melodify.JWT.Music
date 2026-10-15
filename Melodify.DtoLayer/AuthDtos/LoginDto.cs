using System.ComponentModel.DataAnnotations;

namespace Melodify.DtoLayer.AuthDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage ="E-posta zorunludur")]
        [EmailAddress(ErrorMessage ="Lütfen GEÇERLİ bir e-posta giriniz!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre girişi zorunludur")]
        public string Password { get; set; } = string.Empty;
    }
    
}
