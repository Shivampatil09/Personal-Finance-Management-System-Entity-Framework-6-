using Microsoft.AspNetCore.Mvc;

namespace Personal_Finance_MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
