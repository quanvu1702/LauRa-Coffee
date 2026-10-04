using System.ComponentModel.DataAnnotations;

namespace LauraCoffee.Web.ViewModels;

public class CheckoutViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
    [Display(Name = "Họ và tên")]
    public string CustomerName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
    [Phone(ErrorMessage = "Số điện thoại chưa đúng")]
    [Display(Name = "Số điện thoại")]
    public string Phone { get; set; } = string.Empty;
    [Display(Name = "Ghi chú cho quán")]
    public string? Note { get; set; }
}
