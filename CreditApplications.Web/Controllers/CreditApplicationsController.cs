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
            var viewModel = models.Select(model => new CreditApplicationViewModel(model)).ToList();
            
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
            var model = await _creditApplicationLogic.GetById(id);
            var viewModel = new CreditApplicationViewModel(model);
            return View(viewModel);
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreditApplicationViewModel creditApplicationViewModel)
    {
        if (ModelState.IsValid)
        {
            await _creditApplicationLogic.Insert(creditApplicationViewModel.ToModel());
            return RedirectToAction(nameof(List));
        }
        return View(creditApplicationViewModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            _logger.LogInformation("Null ID passed to Edit route.");
            return View("NotFound");
        }

        var creditApplicationModel = await _creditApplicationLogic.GetById(id.Value);
        if (creditApplicationModel == null)
        {
            _logger.LogInformation("No product found for {id}.", id.Value);
            return View("NotFound");
        }

        return View(new CreditApplicationViewModel(creditApplicationModel));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CreditApplicationViewModel viewModel)
    {
        if (id != viewModel.Id) return View("NotFound");

        if (ModelState.IsValid)
        {
            await _creditApplicationLogic.Update(viewModel.ToModel());
            return RedirectToAction(nameof(List));
        }

        return View(viewModel);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return View("NotFound");
        var model = await _creditApplicationLogic.GetById(id.Value);
        if (model == null) return View("NotFound");
        return View(new CreditApplicationViewModel(model));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _creditApplicationLogic.Delete(id);
        return RedirectToAction(nameof(List));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
