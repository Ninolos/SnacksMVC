using SnackMVC.Models;

namespace SnackMVC.ViewModels
{
    public class OrderSnackViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
