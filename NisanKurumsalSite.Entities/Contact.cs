using System.ComponentModel.DataAnnotations;

namespace NisanKurumsalSite.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [Display(Name = "Soyad"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Surname { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [Display(Name = "Telefon"), StringLength(20)]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), StringLength(500), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Message { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
