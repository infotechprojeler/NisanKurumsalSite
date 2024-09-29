using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NisanKurumsalSite.Data;

namespace NisanKurumsalSite.WebUI.ViewComponents
{
    public class Kategoriler : ViewComponent
    {
        private readonly DatabaseContext _context;

        public Kategoriler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Categories.Where(c => c.IsActive).ToListAsync());
        }
    }
}
