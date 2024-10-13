using System.ComponentModel.DataAnnotations;

namespace NisanKurumsalSite.WebUI.Models
{
    public class UserLoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [Display(Name = "Şifre"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
