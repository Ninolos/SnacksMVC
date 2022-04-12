using SnackMVC.Models;

namespace SnackMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Snack> FavoriteSnack { get; set; }
    }
}
