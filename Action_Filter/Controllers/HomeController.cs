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
        private readonly ILogger<HomeController> _logger;
        
        public AuthContext _authContext;
        
        public HomeController(AuthContext context)
        {
            _authContext = context;
        }

        public IActionResult Index()
        {

            var result = _authContext.Authentications.Where(s => s.Id == 1).FirstOrDefault();

            return View();
        }

        public IActionResult Login(UserAuthModel model)
        {
            // Ekrandan gelen veriler ile database'deki verilere göre kullanýcý giriþ mekanizmasý
            var usermodel = _authContext.Authentications.Include(k=>k.Autorizations).Where(s => s.Username == model.Username && s.Password == model.Password).FirstOrDefault();

            if(usermodel != null)
            {
                var Controller = usermodel.Autorizations.Select(s => s.Controller).FirstOrDefault();
                var Action = usermodel.Autorizations.Select(s => s.Action).FirstOrDefault();

                HttpContext.Session.SetString("Controller", Controller);
                HttpContext.Session.SetString("Action", Action);

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
            return View();
        }

    }
}
