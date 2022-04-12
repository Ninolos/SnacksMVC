using Microsoft.AspNetCore.Mvc;

namespace SnackMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
