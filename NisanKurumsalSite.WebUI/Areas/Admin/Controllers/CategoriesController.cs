using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NisanKurumsalSite.Data;
using NisanKurumsalSite.Entities;

namespace NisanKurumsalSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            return View(_context.Categories);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name"); // ekrandaki kategori seçim elemanına veritabanındaki kategorileri gönderiyoruz.
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Categories.Add(collection);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            return View(collection);
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            var model = _context.Categories.Find(id);
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Categories.Update(collection);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            return View(collection);
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.Categories.Find(id);
            return View(model);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                _context.Categories.Remove(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
