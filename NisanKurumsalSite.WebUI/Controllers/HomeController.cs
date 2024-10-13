using Microsoft.AspNetCore.Mvc;
using NisanKurumsalSite.Data;
using NisanKurumsalSite.Entities;
using NisanKurumsalSite.WebUI.Models;
using System.Diagnostics;

namespace NisanKurumsalSite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Slides = _context.Slides.ToList(),
                Products = _context.Products.Where(p => p.IsHome && p.IsActive).ToList(),
                Categories = _context.Categories.Where(c => c.IsHome).ToList(),
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("iletisim")] // adres �ubu�undan iletisim gelince a�a��daki action �al��s�n
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        [Route("iletisim")]
        public async Task<IActionResult> ContactsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Contacts.AddAsync(contact);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                    <strong>Mesaj�n�z G�nderilmi�tir!</strong>
  <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Olu�tu!");
                    TempData["Message"] = "<div class='alert alert-danger'><h2>Hata Olu�tu!</h2><h3>Mesaj�n�z G�nderilemedi!</h3></div>";
                }
            }
            TempData["Message"] = @"<div class=""alert alert-warning alert-dismissible fade show"" role=""alert"">
                    <strong>Mesaj�n�z G�nderilemedi!</strong>
  <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>";
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
