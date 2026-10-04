using LauraCoffee.Web.Models;

namespace LauraCoffee.Web.ViewModels;

public class MenuViewModel
{
    public List<Category> Categories { get; set; } = [];
    public List<AddOn> AddOns { get; set; } = [];
}
