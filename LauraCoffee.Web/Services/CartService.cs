using System.Text.Json;
using LauraCoffee.Web.Models;

namespace LauraCoffee.Web.Services;

public class CartService(IHttpContextAccessor contextAccessor)
{
    private const string CartKey = "laura-cart";
    private ISession Session => contextAccessor.HttpContext!.Session;

    public List<CartItem> GetItems() => JsonSerializer.Deserialize<List<CartItem>>(Session.GetString(CartKey) ?? "[]") ?? [];
    public void Save(List<CartItem> items) => Session.SetString(CartKey, JsonSerializer.Serialize(items));
    public void Add(Product product, string? addOnNames, decimal addOnPrice, int quantity = 1)
    {
        var items = GetItems();
        var item = items.FirstOrDefault(x => x.ProductId == product.ProductId && x.AddOnNames == addOnNames);
        if (item is null) items.Add(new CartItem { ProductId = product.ProductId, ProductName = product.Name, UnitPrice = product.Price, Quantity = quantity, AddOnNames = addOnNames, AddOnPrice = addOnPrice });
        else item.Quantity += quantity;
        Save(items);
    }
    public void ChangeQuantity(int productId, int quantity)
    {
        var items = GetItems(); var item = items.FirstOrDefault(x => x.ProductId == productId);
        if (item is null) return; if (quantity <= 0) items.Remove(item); else item.Quantity = quantity; Save(items);
    }
    public void Clear() => Session.Remove(CartKey);
}
