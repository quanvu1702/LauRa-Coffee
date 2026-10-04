using LauraCoffee.Web.Data;
using LauraCoffee.Web.Models;
using LauraCoffee.Web.Services;
using LauraCoffee.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LauraCoffee.Web.Controllers;

public class CartController(CoffeeDbContext db, CartService cart) : Controller
{
    public IActionResult Index() => View(cart.GetItems());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int productId, int[]? addOnIds)
    {
        var product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == productId && p.IsAvailable);
        if (product is null) return NotFound();
        var selectedAddOns = addOnIds is { Length: > 0 }
            ? await db.AddOns.Where(a => addOnIds.Contains(a.AddOnId) && a.IsAvailable).OrderBy(a => a.AddOnId).ToListAsync()
            : [];
        var addOnNames = selectedAddOns.Any() ? string.Join(", ", selectedAddOns.Select(a => a.Name)) : null;
        cart.Add(product, addOnNames, selectedAddOns.Sum(a => a.Price));
        TempData["Message"] = $"Đã thêm {product.Name} vào giỏ.";
        return RedirectToAction("Index", "Home", new { anchor = "menu" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int productId, int quantity)
    {
        cart.ChangeQuantity(productId, quantity);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        if (!cart.GetItems().Any()) return RedirectToAction(nameof(Index));
        return View(new CheckoutViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Checkout(CheckoutViewModel model)
    {
        var cartItems = cart.GetItems();
        if (!cartItems.Any()) ModelState.AddModelError("", "Giỏ hàng đang trống.");
        if (!ModelState.IsValid) return View(model);

        var order = new Order
        {
            CustomerName = model.CustomerName, Phone = model.Phone, Note = model.Note,
            TotalAmount = cartItems.Sum(x => x.LineTotal),
            Items = cartItems.Select(x => new OrderItem
            {
                ProductId = x.ProductId, ProductName = x.ProductName, UnitPrice = x.UnitPrice,
                Quantity = x.Quantity, AddOnNames = x.AddOnNames, AddOnPrice = x.AddOnPrice
            }).ToList()
        };
        db.Orders.Add(order);
        await db.SaveChangesAsync();
        cart.Clear();
        return RedirectToAction(nameof(Success), new { id = order.OrderId });
    }

    public async Task<IActionResult> Success(int id)
    {
        var order = await db.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.OrderId == id);
        return order is null ? NotFound() : View(order);
    }
}
