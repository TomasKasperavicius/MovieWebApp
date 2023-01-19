namespace Auth.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    public class AuthController : Controller
    {
        public AuthController(){
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}