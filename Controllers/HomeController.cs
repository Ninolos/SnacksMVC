using Microsoft.AspNetCore.Mvc;
using SnackMVC.Models;
using SnackMVC.Repositories.Interfaces;
using SnackMVC.ViewModels;
using System.Diagnostics;

namespace SnackMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public HomeController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FavoriteSnack = _snackRepository.FavoriteSnacks
            };

            return View(homeViewModel);
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}