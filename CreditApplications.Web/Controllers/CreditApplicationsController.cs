using CreditApplications.Web.Models;
using CreditApplications.Web.VewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.Web.ViewModels;

namespace CreditApplications.Web.Controllers;

public class CreditApplicationsController : Controller
{
    private readonly ILogger<CreditApplicationsController> _logger;
    private readonly ICreditApplicationLogic _creditApplicationLogic;

    public CreditApplicationsController(ILogger<CreditApplicationsController> logger, ICreditApplicationLogic creditApplicationLogic)
    {
        _logger = logger;
        _creditApplicationLogic = creditApplicationLogic;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(new HomePageViewModel
            {
                ActiveCreditApplicationsNumber = await _creditApplicationLogic.GetCount()
            });
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
            var models = await _creditApplicationLogic.GetAll();
            var viewModels = models.Select(CreditApplicationViewModel.FromModel).ToList();
            var viewModel = new CreditApplicationListViewModel
            {
                CreditApplications = viewModels
            };
            return View(viewModel);
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

    public IActionResult Create()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
