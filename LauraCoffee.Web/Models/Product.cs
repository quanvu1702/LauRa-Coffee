using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LauraCoffee.Web.Models;

public class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    [Required, StringLength(150)] public string Name { get; set; } = string.Empty;
    [StringLength(300)] public string? Description { get; set; }
    [Column(TypeName = "decimal(18,0)")] public decimal Price { get; set; }
    [StringLength(50)] public string? Unit { get; set; }
    [StringLength(500)] public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; } = true;
    public bool IsFeatured { get; set; }
    public Category? Category { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
