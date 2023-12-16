using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.AboutDto
{
    public class ResultAboutDto
    {
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public int AboutID { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string Title1 { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string Title2 { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public int RoomCount { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public int StaffCount { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public int CustomerCount { get; set; }
    }
}
