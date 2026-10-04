using LauraCoffee.Web.Data;
using LauraCoffee.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LauraCoffee.Web.Controllers;

// Nên bảo vệ controller này bằng đăng nhập/role Admin trước khi triển khai thật.
public class AdminController(CoffeeDbContext db) : Controller
{
    public async Task<IActionResult> Orders() => View(await db.Orders.Include(o => o.Items).OrderByDescending(o => o.CreatedAt).ToListAsync());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, OrderStatus status)
    {
        var order = await db.Orders.FindAsync(id);
        if (order is not null) { order.Status = status; await db.SaveChangesAsync(); }
        return RedirectToAction(nameof(Orders));
    }
}
