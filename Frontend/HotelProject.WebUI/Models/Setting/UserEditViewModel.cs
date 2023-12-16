using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Setting
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar Alanı Gereklidir.")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
