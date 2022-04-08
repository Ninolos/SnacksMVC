using System.ComponentModel.DataAnnotations;

namespace SnackMVC.Models
{
    public class ShopCartItem
    {
        public int ShopCartItemId { get; set; }
        public Snack Snack { get; set; }
        public int Amount { get; set; }

        [StringLength(200)]
        public string ShopCartId { get; set; } // to create a GUID
    }
}
