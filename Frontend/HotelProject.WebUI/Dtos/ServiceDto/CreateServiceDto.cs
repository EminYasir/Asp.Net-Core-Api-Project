using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        
        [Required(ErrorMessage ="Hizmet başlığı giriniz")]
        [StringLength(100,ErrorMessage = "Hizmet başlığı en fazla karakter olmalı")] 
        public string Title { get; set; }

        [Required(ErrorMessage ="Hizmet detayı giriniz")]
        public string Description { get; set; }
    }
}
