using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
public class NotesController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public NotesController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var notes = await _context.Notes.Where(n => n.UserId == userId).ToListAsync();
        return View(notes);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string content)
    {
        var userId = _userManager.GetUserId(User);
        _context.Notes.Add(new Note { UserId = userId, Content = content });
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
