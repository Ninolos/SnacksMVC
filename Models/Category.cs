using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackMVC.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(100, ErrorMessage = "the maximum size is 100 characters")]
        [Required(ErrorMessage ="Inform the Category Name")]
        [Display(Name ="Name")]
        public string CategoryName { get; set; }

        [StringLength(200, ErrorMessage = "the maximum size is 200 characters")]
        [Required(ErrorMessage = "Inform the Category Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<Snack> Snacks { get; set; }
    }
}
