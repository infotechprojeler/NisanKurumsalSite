using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NisanKurumsalSite.Data;
using NisanKurumsalSite.Entities;

namespace NisanKurumsalSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidesController : Controller
    {
        private readonly DatabaseContext _context;

        public SlidesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: SlidesController
        public ActionResult Index()
        {
            return View(_context.Slides);
        }

        // GET: SlidesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slide collection, IFormFile? Image)
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
                    _context.Slides.Add(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(collection);
        }

        // GET: SlidesController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.Slides.Find(id);
            return View(model);
        }

        // POST: SlidesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Slide collection, IFormFile? Image, bool cbResmiSil)
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
                    _context.Slides.Update(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(collection);
        }

        // GET: SlidesController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.Slides.Find(id);
            return View(model);
        }

        // POST: SlidesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Slide collection)
        {
            try
            {
                _context.Slides.Remove(collection);
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
