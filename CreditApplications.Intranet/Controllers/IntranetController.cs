using CreditApplications.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CreditApplications.Intranet.ViewModels;
using Microsoft.EntityFrameworkCore;
using CreditApplications.DataAccess;

namespace CreditApplications.Intranet.Controllers;

public class IntranetController : Controller
{
    private readonly ILogger<IntranetController> _logger;
    private readonly CreditApplicationsDbContext _context;

    public IntranetController(ILogger<IntranetController> logger, CreditApplicationsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(new HomePageViewModel
            {
                Messages = await _context.Messages.Where(x => x.IsActive).ToListAsync()
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get credit applications count: {e}");
            return RedirectToAction(nameof(Error));
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
