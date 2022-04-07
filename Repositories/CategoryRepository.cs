using SnackMVC.Context;
using SnackMVC.Models;
using SnackMVC.Repositories.Interfaces;

namespace SnackMVC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}
