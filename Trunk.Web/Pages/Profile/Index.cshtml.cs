using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Trunk.Web.Data.Entities;
using Trunk.Web.Models.Profile;

namespace Trunk.Web.Pages.Profile;

public class IndexModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileViewModel ProfileViewModel { get; set; } = default!;

    public IndexModel(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGet(string userName)
    {
        if (string.IsNullOrEmpty(userName)) {
            userName = User.Identity?.Name!;
        }

        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return NotFound("Not found.");
        }

        ProfileViewModel = new ProfileViewModel
        {
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
        };

        return Page();
    }
}
