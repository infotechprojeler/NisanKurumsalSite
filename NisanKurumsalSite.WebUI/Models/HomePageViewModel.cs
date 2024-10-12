using NisanKurumsalSite.Entities;

namespace NisanKurumsalSite.WebUI.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Slide>? Slides { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public Contact? Contact { get; set; }
    }
}
