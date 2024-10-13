using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NisanKurumsalSite.Data;
using NisanKurumsalSite.Entities;
using NisanKurumsalSite.WebUI.Models;
using System.Security.Claims;

namespace NisanKurumsalSite.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _context;

        public AccountController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateViewModel userCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User()
                    {
                        Name = userCreateViewModel.Name,
                        Surname = userCreateViewModel.Surname,
                        Email = userCreateViewModel.Email,
                        IsActive = true,
                        IsAdmin = false,
                        Password = userCreateViewModel.Password,
                        Phone = userCreateViewModel.Phone
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                    <strong>Üye Kaydınız Oluşturulmuştur!</strong>
  <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>";
                    return RedirectToAction("Login");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(userCreateViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var kullanici = _context.Users.FirstOrDefault(u => u.IsActive && u.Email == userLoginViewModel.Email && u.Password == userLoginViewModel.Password);
                    if (kullanici == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız!");
                    }
                    else
                    {
                        // Kullanıcıya giriş için vermek istediğimiz hakları tanımlıyoruz
                        var haklar = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Email, kullanici.Email),
                            new Claim(ClaimTypes.Name, kullanici.Name),
                            new Claim(ClaimTypes.Role, kullanici.IsAdmin ? "Admin" : "User")
                        };
                        // kullanıcıya kimlik tanımlıyoruz
                        var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcıya tanıdığımız hakları kimliğe işliyoruz
// kullanıcıya verdiğimiz kimlik ile tanımlı kurallardan oluşan nesne oluşturuyoruz
                        var claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi);
                        // Yetkilendirme ile sisteme girişi yapıyoruz
                        await HttpContext.SignInAsync(claimsPrincipal);
                        // Giriş sonrası tarayıcıda returnurl varsa
                        if (!string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]))
                        {
                            return Redirect(HttpContext.Request.Query["ReturnUrl"]); // kullanıcıyı ReturnUrl deki gitmek istediği adrese yönlendir
                        }
                        return RedirectToAction("Index"); // ReturnUrl yoksa anasayfaya yönlendir
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(userLoginViewModel);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
