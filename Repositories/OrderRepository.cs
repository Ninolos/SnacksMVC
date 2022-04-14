using SnackMVC.Context;
using SnackMVC.Models;
using SnackMVC.Repositories.Interfaces;

namespace SnackMVC.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _addDbContext;
        private readonly ShopCart _shopCart;

        public OrderRepository(AppDbContext addDbContext, ShopCart shopCart)
        {
            _addDbContext = addDbContext;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderSent = DateTime.Now;
            _addDbContext.Orders.Add(order);
            _addDbContext.SaveChanges();

            var shopCartItens = _shopCart.ShopCartItens;

            foreach (var cartItem in shopCartItens)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = cartItem.Amount,
                    SnackId = cartItem.Snack.SnackId,
                    OrderId = order.OrderId,
                    Price = cartItem.Snack.Price,
                };
                _addDbContext.OrderDetails.Add(orderDetail);
            }
            _addDbContext.SaveChanges();
        }
    }
}
