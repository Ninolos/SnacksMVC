using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackMVC.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Amount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Snack Snack { get; set; }
        public int SnackId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
