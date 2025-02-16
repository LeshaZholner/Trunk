using System.ComponentModel.DataAnnotations;

namespace Trunk.Web.Models.Account;

public class LoginInputModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;
    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}
