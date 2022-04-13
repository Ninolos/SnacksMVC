using Microsoft.AspNetCore.Mvc;
using SnackMVC.Models;
using SnackMVC.Repositories.Interfaces;
using SnackMVC.ViewModels;

namespace SnackMVC.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackrepository;

        public SnackController(ISnackRepository snackrepository)
        {
            _snackrepository = snackrepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                snacks = _snackrepository.Snacks.OrderBy(l => l.SnackId);
                currentCategory = "All Snacks";
            }
            else
            {
                if (string.Equals("Normal", category, StringComparison.OrdinalIgnoreCase))
                {
                    snacks = _snackrepository.Snacks
                                  .Where(l => l.Category.CategoryName.Equals("Normal"))
                                  .OrderBy(l => l.Name);
                }
                else
                {
                    snacks = _snackrepository.Snacks
                                  .Where(l => l.Category.CategoryName.Equals("Natural"))
                                  .OrderBy(l => l.Name);
                }

                currentCategory = category;
            }

            var snackListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCategory
            };

            return View(snackListViewModel);
        }
    }
}
