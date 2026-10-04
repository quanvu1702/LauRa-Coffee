namespace LauraCoffee.Web.Models;

public class CartItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; } = 1;
    public string? AddOnNames { get; set; }
    public decimal AddOnPrice { get; set; }
    public decimal LineTotal => (UnitPrice + AddOnPrice) * Quantity;
}
