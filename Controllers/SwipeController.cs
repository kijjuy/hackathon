using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

public class SwipeController: Controller {

    private readonly UserManager<ApplicationUser> _userManager;

    public SwipeController(UserManager<ApplicationUser> userManager) {
        _userManager = userManager;
    }

    [Authorize]
    public IActionResult Index() {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> DisplayUser(string userId) {
        var user = _userManager.FindByIdAsync(userId);
        //return View(user.)
        return View();
    }
}