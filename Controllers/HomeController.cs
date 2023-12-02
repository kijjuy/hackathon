using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using hackathon.Models;
using Microsoft.AspNetCore.Authorization;
using hackathon.Data;
using Microsoft.AspNetCore.Identity;

namespace hackathon.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;


    public HomeController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if(user.Description != null || user.Description != "") {
            return RedirectToAction(nameof(SwipeController.Index), "Swipe");
        }
        return View("CreateProfile");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateProfile([Bind] UserViewModel userViewModel) {
        if(ModelState.IsValid) {
            var user = await _userManager.GetUserAsync(User);
            user.Description = userViewModel.Description;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        return Error();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}