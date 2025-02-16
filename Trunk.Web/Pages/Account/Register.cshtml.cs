using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Trunk.Web.Data.Entities;
using Trunk.Web.Models.Account;

namespace Trunk.Web.Pages.Account;

public class RegisterModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    [BindProperty]
    public RegisterInputModel InputModel { get; set; } = default!;

    public RegisterModel(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
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

        var user = CreateUser();

        await _userManager.SetUserNameAsync(user, await GenerateUserName(InputModel.Email));
        await _userManager.SetEmailAsync(user, InputModel.Email);
        var result = await _userManager.CreateAsync(user, InputModel.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);

            return RedirectToPage("/Index");
        }

        return Page();
    }

    private ApplicationUser CreateUser()
    {
        return new ApplicationUser();
    }

    private async Task<string> GenerateUserName(string email)
    {
        var userName = email.Split('@')[0];
        userName = NormalizeUserName(userName);
        var baseUserName = userName;
        var counter = 1;

        while(await _userManager.FindByNameAsync(userName) != null)
        {
            userName = $"{baseUserName}_{counter}";
            counter++;
        }

        return userName;
    }

    private static string NormalizeUserName(string userName)
    {
        return userName.ToLower().Replace(".", "").Replace("+", "");
    }
}
