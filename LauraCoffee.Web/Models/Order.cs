using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LauraCoffee.Web.Models;

public enum OrderStatus { Pending, Confirmed, Preparing, Completed, Cancelled }

public class Order
{
    public int OrderId { get; set; }
    [Required, StringLength(80)] public string CustomerName { get; set; } = string.Empty;
    [Required, StringLength(20)] public string Phone { get; set; } = string.Empty;
    [StringLength(300)] public string? Note { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    [Column(TypeName = "decimal(18,0)")] public decimal TotalAmount { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    [Required, StringLength(150)] public string ProductName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,0)")] public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    [StringLength(300)] public string? AddOnNames { get; set; }
    [Column(TypeName = "decimal(18,0)")] public decimal AddOnPrice { get; set; }
    public Order? Order { get; set; }
    public Product? Product { get; set; }
}
