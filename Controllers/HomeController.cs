using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using hackathon.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
using hackathon.Data;
using Microsoft.AspNetCore.Identity;

namespace hackathon.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ApplicationDbContext _context;

    public HomeController(
        ILogger<HomeController> logger,
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager
        )
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if(user.Description != null && user.Description != "") {
            Console.WriteLine($"{user.Description}");
            return View();
        }
        return View("CreateProfile");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateDescription() {
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
