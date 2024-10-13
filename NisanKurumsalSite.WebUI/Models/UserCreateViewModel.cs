using System.ComponentModel.DataAnnotations;

namespace NisanKurumsalSite.WebUI.Models
{
    public class UserCreateViewModel
    {
        [Display(Name = "Ad"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [Display(Name = "Soyad"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Surname { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [Display(Name = "Telefon"), StringLength(20)]
        public string? Phone { get; set; }
        [Display(Name = "Şifre"), StringLength(50)]
        public string Password { get; set; }
    }
}
