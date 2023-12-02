using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using hackathon.ViewModels;
using hackathon.Data;

public class SwipeController: Controller {

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ApplicationDbContext _context;

    public SwipeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context) {
        _userManager = userManager;
        _context = context;
    }

    [Authorize]
    public IActionResult Index() {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> DisplayUser(string userId) {
        ApplicationUser user = await _userManager.FindByIdAsync("ef9582c4-dea2-4735-9315-628c32d47339");
        var viewModel = new UserSwipeViewModel();
        viewModel.Description = user.Description;
        return View(viewModel);
    }
}