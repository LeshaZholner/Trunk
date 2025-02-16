using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Trunk.Web.Data.Entities;
using Trunk.Web.Models.Account;

namespace Trunk.Web.Pages.Account;

public class LoginModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    [BindProperty]
    public LoginInputModel InputModel { get; set; } = default!;

    public LoginModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(InputModel.Email, InputModel.Password, InputModel.RememberMe, false);

        if (result.Succeeded)
        {
            return RedirectToPage("/Index");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");

        return Page();
    }
}
