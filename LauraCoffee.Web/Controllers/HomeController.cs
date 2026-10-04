using LauraCoffee.Web.Data;
using LauraCoffee.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LauraCoffee.Web.Controllers;

public class HomeController(CoffeeDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await db.Categories.Where(c => c.IsActive)
            .OrderBy(c => c.DisplayOrder).Include(c => c.Products.Where(p => p.IsAvailable)).ToListAsync();
        return View(new MenuViewModel
        {
            Categories = categories,
            AddOns = await db.AddOns.Where(x => x.IsAvailable).OrderBy(x => x.Price).ToListAsync()
        });
    }
}
