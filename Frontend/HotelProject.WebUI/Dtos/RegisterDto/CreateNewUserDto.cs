using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad Alanı Gereklidir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadı Alanı Gereklidir.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şehir Alanı Gereklidir.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı Alanı Gereklidir.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mail Alanı Gereklidir.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Resim Url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Cinsiyet")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Ülke")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı Gereklidir.")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }



    }
}
