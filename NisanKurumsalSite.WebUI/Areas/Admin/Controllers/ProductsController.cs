using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NisanKurumsalSite.Data;
using NisanKurumsalSite.Entities;

namespace NisanKurumsalSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            return View(_context.Products.Include(p => p.Category));
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null)
                    {
                        string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // dosyayı yükleyeceğimiz klasör
                        using var stream = new FileStream(klasor + Image.FileName, FileMode.Create);
                        Image.CopyTo(stream);
                        collection.Image = Image.FileName;
                    }
                    _context.Products.Add(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View(collection);
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            var model = _context.Products.Find(id);
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection, IFormFile? Image, bool cbResmiSil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (cbResmiSil == true)
                    {
                        collection.Image = "";
                    }
                    if (Image is not null)
                    {
                        string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // dosyayı yükleyeceğimiz klasör
                        using var stream = new FileStream(klasor + Image.FileName, FileMode.Create);
                        Image.CopyTo(stream);
                        collection.Image = Image.FileName;
                    }
                    _context.Products.Update(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View(collection);
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.Products.Find(id);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                _context.Products.Remove(collection);
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
