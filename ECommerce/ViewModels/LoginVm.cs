using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels;

public class LoginVM
{
    [Required(ErrorMessage = "EPosta adresi gereklidir.")]
    [Display(Name = "EPosta Adresi")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir.")]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre")]
    public string Password { get; set; }
}
