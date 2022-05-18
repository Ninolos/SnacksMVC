using SnackMVC.Context;
using SnackMVC.Models;

namespace SnackMVC.Areas.Admin.Services
{
    public class SalesGraphService
    {
        private readonly AppDbContext context;

        public SalesGraphService(AppDbContext context)
        {
            this.context = context;
        }

    }

}
