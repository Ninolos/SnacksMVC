using SnackMVC.Models;

namespace SnackMVC.Repositories.Interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }

        IEnumerable<Snack> FavoriteSnacks { get; }

        Snack GetSnackById(int snackId);
    }
}
