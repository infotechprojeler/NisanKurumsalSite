using System.ComponentModel.DataAnnotations;

namespace NisanKurumsalSite.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
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
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
