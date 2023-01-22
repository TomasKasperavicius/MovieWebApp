namespace Auth.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class AuthController : Controller
    {
        public AuthController(){
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            return View(login);
        }
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return View(user);
        }
    }
}