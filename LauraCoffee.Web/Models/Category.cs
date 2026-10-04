using System.ComponentModel.DataAnnotations;

namespace LauraCoffee.Web.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Required, StringLength(100)] public string Name { get; set; } = string.Empty;
    [StringLength(20)] public string Icon { get; set; } = "☕";
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
