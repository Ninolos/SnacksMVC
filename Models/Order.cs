using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage ="Inform Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Inform Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Inform Adress")]
        [StringLength(100)]
        [Display(Name="Adress")]
        public string Adress1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Complement")]
        public string Adress2 { get; set; }

        [Required(ErrorMessage ="Inform the ZIP code")]
        [Display(Name="ZIP-code")]
        [StringLength(10, MinimumLength = 8)]
        public string ZIP { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Inform Phone Number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Inform Email")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Total Order")]
        public decimal TotalOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Total Itens")]
        public int TotalOrderItens { get; set; }

        [Display(Name="Order Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OrderSent { get; set; }

        [Display(Name = "Order Delivered")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDelivered { get; set; }

        public List<OrderDetail> OrderItens { get; set; }
    }
}
