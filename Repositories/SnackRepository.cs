using Microsoft.EntityFrameworkCore;
using SnackMVC.Context;
using SnackMVC.Models;
using SnackMVC.Repositories.Interfaces;

namespace SnackMVC.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;

        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Snack> Snacks => _context.Snacks.Include(c => c.Category);

        public IEnumerable<Snack> FavoriteSnacks => _context.Snacks.Where(l => l.FavoriteSnack).Include(c => c.Category);

        public Snack GetSnackById(int snackId)
        {
            return _context.Snacks.FirstOrDefault(l => l.SnackId == snackId);
        }
    }
}
