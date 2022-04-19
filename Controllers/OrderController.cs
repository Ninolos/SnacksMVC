using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnackMVC.Models;
using SnackMVC.Repositories.Interfaces;

namespace SnackMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShopCart _shopCart;

        public OrderController(IOrderRepository orderRepository, ShopCart shopCart)
        {
            _orderRepository = orderRepository;
            _shopCart = shopCart;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int orderTotalItens = 0;
            decimal orderTotalPrice = 0.0m;

            // get itens from shop cart
            List<ShopCartItem> items = _shopCart.GetShopCartItems();
            _shopCart.ShopCartItens = items;

            //check if have order items 
            if (_shopCart.ShopCartItens.Count == 0)
            {
                ModelState.AddModelError("", "Your Cart is empty");
            }

            //sum the total items and total price
            foreach(var item in items)
            {
                orderTotalItens += item.Amount;
                orderTotalPrice += (item.Snack.Price * item.Amount);
            }

            //add values to the Order
            order.TotalOrderItens = orderTotalItens;
            order.TotalOrder = orderTotalPrice;

            //Validate order data
            if (ModelState.IsValid)
            {
                //if is valid create the order and details
                _orderRepository.CreateOrder(order);

                //messages to client
                ViewBag.CheckoutCompletedMessage = "Thanks for your Order";
                ViewBag.TotalOrder = _shopCart.GetCartTotalBuy();

                //clear Cart
                _shopCart.ClearCart();

                //return view with client and order infos
                return View("~/Views/Order/CheckoutCompleted.cshtml", order);
            }
            return View(order);
        }
    }
}
