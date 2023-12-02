using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using hackathon.ViewModels;
using hackathon.Data;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
    public async Task<IActionResult> DisplayUser([Bind] int usernum) {
        Console.WriteLine($"usernum is: {usernum} --------------------------------------------");
        var users = await _context.Users.ToListAsync();
        var currentUser = await _userManager.GetUserAsync(User);
        users.Where(user => user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
        List<UserSwipeViewModel> models = new List<UserSwipeViewModel>();
        foreach(ApplicationUser user in users) {
            UserSwipeViewModel vmodel = new UserSwipeViewModel();
            vmodel.Description = user.Description;
            models.Add(vmodel);
        } 
        Console.WriteLine($"model count: {models.Count()} -------------------------------------");
        PageViewModel newModel = new PageViewModel {
            Description = models[usernum].Description,
            Count = usernum,
        };
        return View(newModel);
    }
}