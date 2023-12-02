using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using hackathon.Models;
using Microsoft.AspNetCore.Authorization;
using hackathon.Data;
using Microsoft.AspNetCore.Identity;

public class SwipeController: Controller {

    private readonly UserManager<ApplicationUser> _userManager;

    public SwipeController(UserManager<ApplicationUser> userManager) {
        _userManager = userManager;
    }

    public IActionResult Index() {
        return View();
    }
}