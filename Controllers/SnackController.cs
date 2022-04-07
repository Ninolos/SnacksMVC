using Microsoft.AspNetCore.Mvc;
using SnackMVC.Repositories.Interfaces;

namespace SnackMVC.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackrepository;

        public SnackController(ISnackRepository snackrepository)
        {
            _snackrepository = snackrepository;
        }

        public IActionResult List()
        {
            var snacks = _snackrepository.Snacks;
            return View(snacks);
        }
    }
}
