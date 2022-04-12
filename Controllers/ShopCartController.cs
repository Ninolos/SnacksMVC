using Microsoft.AspNetCore.Mvc;
using SnackMVC.Models;
using SnackMVC.Repositories.Interfaces;
using SnackMVC.ViewModels;

namespace SnackMVC.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(ISnackRepository snackRepository, ShopCart shopCart)
        {
            _snackRepository = snackRepository;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            var itens = _shopCart.GetShopCartItems();
            _shopCart.ShopCartItens = itens;

            var shopCartVM = new ShopCartViewModel
            {
                ShopCart = _shopCart,
                ShopCartTotal = _shopCart.GetCartTotalBuy()
            };

            return View(shopCartVM);
        }

        public IActionResult AddItemtoCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(s => s.SnackId == snackId);

            if(selectedSnack != null)
            {
                _shopCart.AddToCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemFromCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks.FirstOrDefault(s => s.SnackId == snackId);

            if (selectedSnack != null)
            {
                _shopCart.RemoveFromCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }
    }
}
