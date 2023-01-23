using CreditApplications.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Logic;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using CreditApplications.DataAccess;

namespace CreditApplications.Web.Controllers;

public class CreditApplicationsController : Controller
{
    private readonly ILogger<CreditApplicationsController> _logger;
    private readonly ICreditApplicationLogic _creditApplicationLogic;
    private readonly ICustomerLogic _customerLogic;
    private readonly CreditApplicationsDbContext _context;

    public CreditApplicationsController(ILogger<CreditApplicationsController> logger, ICreditApplicationLogic creditApplicationLogic, ICustomerLogic customerLogic, CreditApplicationsDbContext context)
    {
        _logger = logger;
        _creditApplicationLogic = creditApplicationLogic;
        _customerLogic = customerLogic;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(new HomePageViewModel
            {
                ActiveCreditApplicationsNumber = await _creditApplicationLogic.GetCount(),
                CustomersCount = await _customerLogic.GetCount(),
                Messages = await _context.Messages.Where(x => x.IsActive).ToListAsync()
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

    [Route("Details/{id:int}")]
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

    public async Task<IActionResult> Create()
    {
        var model = await _creditApplicationLogic.Initialize(new CreditApplication());
        var viewModel = new CreditApplicationViewModel(model);
        viewModel.Initialize();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreditApplicationViewModel creditApplicationViewModel)
    {
        if (ModelState.IsValid)
        {
            await _creditApplicationLogic.Create(creditApplicationViewModel.ToModel());
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

        var viewModel = new CreditApplicationViewModel(await _creditApplicationLogic.Initialize(creditApplicationModel));
        viewModel.Initialize();

        return View(viewModel);
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
