using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.LoginDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifreyi Giriniz")]
        public string Password { get; set; }
    }
}
