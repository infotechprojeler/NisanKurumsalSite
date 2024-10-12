using System.ComponentModel.DataAnnotations;

namespace NisanKurumsalSite.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Kategori Resmi"), StringLength(100)]
        public string? Image { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfada Göster")]
        public bool IsHome { get; set; }
        [Display(Name = "Üst Menüde Göster")]
        public bool IsTopMenu { get; set; }
        [Display(Name = "Üst Menü")]
        public int ParentId { get; set; }
        [Display(Name = "Sıra No")]
        public int OrderNo { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn özelliği mvc de crud sayfaları oluşturulurken bu kolon ekranda oluşturulsun mu bunu ayarlar, false değeri ekranda oluşturulmasını engeller.
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public List<Product>? Products { get; set; } // kategori ile ürünler arasında bire çok ilişki kurduk
    }
}
