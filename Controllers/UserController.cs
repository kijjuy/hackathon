using Microsoft.AspNetCore.Mvc;
using hackathon.Data;

[ApiController]
[Route("controller")]
public class UserController : ControllerBase
{

    private readonly ApplicationDbContext _context;


    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetUserInfo()
    {
        return Ok("foo");
    }

}
