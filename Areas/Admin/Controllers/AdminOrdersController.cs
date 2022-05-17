using SnackMVC.Context;
using SnackMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SnackMVC.ViewModels;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public AdminOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminPedidos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Orders.ToListAsync());
        //}

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Name")
        {
            var result = _context.Orders.AsNoTracking()
                                        .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                result = result.Where(p => p.Name.Contains(filter));
            }

            var model = await PagingList.CreateAsync(result, 5, pageindex, sort, "Name");
            model.RouteValue = new RouteValueDictionary { { "filter ", filter } };
            return View(model);
        }

        // GET: Admin/AdminPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Admin/AdminPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Name,LastName,Adress1,Adress2,ZIP,State,City,Telephone,Email,OrderSent,OrderDelivered")] Order pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Admin/AdminPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Orders.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Admin/AdminPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Name,LastName,Adress1,Adress2,ZIP,State,City,Telephone,Email,OrderSent,OrderDelivered")] Order pedido)
        {
            if (id != pedido.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Admin/AdminPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Admin/AdminPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

        public IActionResult SnackOrder(int? id)
        {
            var order = _context.Orders
                                .Include(or => or.OrderItens)
                                .ThenInclude(s => s.Snack)
                                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                Response.StatusCode = 404;
                return View("OrderNotFound", id.Value);
            }

            OrderSnackViewModel orderSnack = new OrderSnackViewModel()
            {
                Order = order,
                OrderDetails = order.OrderItens
            };

            return View(orderSnack);
        }
    }
}
