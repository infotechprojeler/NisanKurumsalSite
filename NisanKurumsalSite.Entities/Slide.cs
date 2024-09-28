using System.ComponentModel.DataAnnotations;

namespace NisanKurumsalSite.Entities
{
    public class Slide : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        public string? Title { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; } = null;
        public string? Url { get; set; }
        [Display(Name = "Resim"), StringLength(100)]
        public string? Image { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
