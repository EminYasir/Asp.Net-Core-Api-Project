using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {

        
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla karakter olmalı")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet detayı giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet detayı en fazla karakter olmalı")]
        public string Description { get; set; }
    }
}
