using System.ComponentModel.DataAnnotations;

namespace SnackMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Inform Name")]
        [Display(Name ="User")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Inform Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Passwprd")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
