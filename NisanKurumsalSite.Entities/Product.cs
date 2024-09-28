using System.ComponentModel.DataAnnotations;

namespace NisanKurumsalSite.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [Display(Name = "Ürün Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Ürün Resmi"), StringLength(100)]
        public string? Image { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfada Göster")]
        public bool IsHome { get; set; }
        [Display(Name = "Stok"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int Stock { get; set; }
        [Display(Name = "Fiyat"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public decimal Price { get; set; }
        [Display(Name = "Sıra No")]
        public int OrderNo { get; set; }
        [Display(Name = "Kategori")]
        public int? CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public Category? Category { get; set; } // navigation property
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
