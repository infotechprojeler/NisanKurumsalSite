using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NisanKurumsalSite.Data;
using NisanKurumsalSite.Entities;

namespace NisanKurumsalSite.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(string q = "")
        {
            var model = _context.Products.Where(p => p.IsActive && p.Name.Contains(q));
            return View(model);
        }

        public IActionResult Detail(int? id)
        {
            if (id is null) // eğer tarayıcıdan id gönderilmemişse
            {
                return BadRequest(); // geriye geçersiz istek hatası dön
            }
            Product model = _context.Products.Include(c => c.Category).FirstOrDefault(p => p.Id == id);
            if (model == null) // tarayıcıdan gönderilen id ye ait veritabanında ürün yoksa
            {
                return NotFound(); // geriye kullanıcıya notfound-bulunamadı hatası dön
            }
            return View(model);
        }
    }
}
