using System.ComponentModel.DataAnnotations;

namespace Trunk.Web.Models.Account;

public class RegisterInputModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirm pasword don't match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
