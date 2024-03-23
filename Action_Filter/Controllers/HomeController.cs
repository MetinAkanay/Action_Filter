using Action_Filter.ActionFilter;
using Action_Filter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Action_Filter.Controllers
{
    [AutorizeActionFilter]
    public class HomeController : Controller
    {
        
        public AuthContext _context;
        
        public HomeController(AuthContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(UserAuthModel model)
        {
            // Ekrandan gelen veriler ile database'deki verilere göre kullanıcı giriş mekanizması
            var usermodel = _context.Authentications.Include(k=>k.Autorizations).Where(s => s.Username == model.Username && s.Password == model.Password).FirstOrDefault();

            if(usermodel != null)
            {
                var controller = usermodel.Autorizations.Select(s => s.Controller).FirstOrDefault();
                var action = usermodel.Autorizations.Select(s => s.Action).FirstOrDefault();

                HttpContext.Session.SetString("controller", controller);
                HttpContext.Session.SetString("action", action);

                return View("Login");
            }
            else
            {
                return View("Index");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View("Error");
        }

    }
}
