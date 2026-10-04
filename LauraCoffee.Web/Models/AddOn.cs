using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LauraCoffee.Web.Models;

public class AddOn
{
    public int AddOnId { get; set; }
    [Required, StringLength(100)] public string Name { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,0)")] public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
}
