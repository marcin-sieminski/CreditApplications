using CreditApplications.Web.Models;
using CreditApplications.Web.VewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreditApplications.Web.Controllers;

public class CreditApplicationsController : Controller
{
    private readonly ILogger<CreditApplicationsController> _logger;

    public CreditApplicationsController(ILogger<CreditApplicationsController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(new HomePageViewModel());
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get credit applications count: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    public async Task<IActionResult> List()
    {
        try
        {
            return View();
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get credit applications: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    [Route("{id:int}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        try
        {
            return View();
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get credit application details: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
