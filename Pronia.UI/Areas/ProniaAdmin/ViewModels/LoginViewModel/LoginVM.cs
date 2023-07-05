using System.ComponentModel.DataAnnotations;

namespace Pronia.UI.Areas.ProniaAdmin.ViewModels.LoginViewModel;

public class LoginVM
{
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }=null!;
    public bool RememberMe { get; set; }
}
