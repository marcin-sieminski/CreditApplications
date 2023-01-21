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
            var viewModels = models.Select(model => new CreditApplicationViewModel(model)).ToList();
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

        return View(CreditApplicationViewModel.FromModel(creditApplicationModel));
    }

    // POST: ProductsData/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductModel product)
    {
        if (id != product.Id) return View("NotFound");

        if (ModelState.IsValid)
        {
            await _productLogic.UpdateProduct(product);

            return RedirectToAction(nameof(Index));
        }

        await _productLogic.GetAvailableCategories(product);
        return View(product);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
