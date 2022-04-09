using SnackMVC.Context;

namespace SnackMVC.Models
{
    public class ShopCart
    {
        private readonly AppDbContext _context;

        public ShopCart(AppDbContext context)
        {
            _context = context;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            //define session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //get a service from context
            var context = services.GetService<AppDbContext>();

            //get or create a Cart Id
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //set the Id to the session cart
            session.SetString("CartId", cartId);

            //return a cart with the context and Id
            return new ShopCart(context)
            {
                ShopCartId = cartId
            };
        }

        public void AddToCart(Snack snack)
        {
            var shopCartItem = _context.ShopCartItens.SingleOrDefault(s => s.Snack.SnackId == snack.SnackId
            && s.ShopCartId == ShopCartId);

            if(shopCartItem == null)
            {
                shopCartItem = new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    Snack = snack,
                    Amount = 1
                };
                _context.ShopCartItens.Add(shopCartItem);
            }
            else
            {
                shopCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(Snack snack)
        {
            var shopCartItem = _context.ShopCartItens.SingleOrDefault(s => s.Snack.SnackId == snack.SnackId
            && s.ShopCartId == ShopCartId);            

            if(shopCartItem != null)
            {
                if(shopCartItem.Amount > 1)
                {
                    shopCartItem.Amount--;                    
                }
                else
                {
                    _context.ShopCartItens.Remove(shopCartItem);
                }
            }
            _context.SaveChanges();            
        }
    }
}
