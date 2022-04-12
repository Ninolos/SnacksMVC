using Microsoft.AspNetCore.Mvc;
using SnackMVC.Models;
using SnackMVC.ViewModels;

namespace SnackMVC.Components
{
    public class ShopCartResume : ViewComponent
    {
        private readonly ShopCart _shopCart;

        public ShopCartResume(ShopCart shopCart)
        {
            _shopCart = shopCart;
        }

        public IViewComponentResult Invoke()
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
    }
}
