using SnackMVC.Models;

namespace SnackMVC.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
