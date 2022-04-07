using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackMVC.Models
{
    [Table("Snacks")]
    public class Snack
    {
        [Key]
        public int SnackId { get; set; }

        [StringLength(100, ErrorMessage = "the maximum size is 100 characters")]
        [Required(ErrorMessage = "Inform the Snack Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "the maximum size is 200 characters")]
        [Required(ErrorMessage = "Inform a Snack Description")]
        [Display(Name = "Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Inform a Snack Description")]
        [StringLength(300, ErrorMessage = "the maximum size is 300 characters")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage ="Inform the Snack Price")]
        [Display(Name ="Price")]
        [Column(TypeName="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage = "Price is only between R$1 and R$999")]
        public decimal Price { get; set; }

        [Display(Name ="Image Url")]
        [StringLength(200, ErrorMessage = "the maximum size is 200 characters")]
        public string ImageUrl { get; set; }

        [Display(Name = "Image Thumb Url")]
        [StringLength(200, ErrorMessage = "the maximum size is 200 characters")]
        public string ImageThumbUrl { get; set; }

        [Display(Name = "Favorite Snack?")]
        public bool FavoriteSnack { get; set; }

        [Display(Name = "In Stock?")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
