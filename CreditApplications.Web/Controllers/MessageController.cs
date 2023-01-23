using CreditApplications.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditApplications.Web.Controllers;

public class MessageController : Controller
{
    private readonly CreditApplicationsDbContext _context;

    public MessageController(CreditApplicationsDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? id)
    {
        ViewBag.MessageModel = _context.Messages.Where(x => x.IsActive).OrderByDescending(x => x.Created).ToList();
        var item = await _context.Messages.FirstOrDefaultAsync(x => x.IsActive && x.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
}