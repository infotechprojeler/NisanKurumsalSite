using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NisanKurumsalSite.Data;

namespace NisanKurumsalSite.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }
    }
}
