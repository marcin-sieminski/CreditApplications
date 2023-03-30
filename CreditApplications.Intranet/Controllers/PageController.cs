using Microsoft.AspNetCore.Mvc;
using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.Intranet.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CreditApplications.Intranet.Controllers;

[Authorize]
public class PageController : Controller
{
    private readonly ILogger<PageController> _logger;
    private readonly IPageLogic _pageLogic;

    public PageController(ILogger<PageController> logger, IPageLogic logic)
    {
        _logger = logger;
        _pageLogic = logic;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(new IntranetViewModel
            {
                Pages = await _pageLogic.GetAllSorted()
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get page: {e}");
            return RedirectToAction(nameof(Error));
        }
    }


    [Route("{controller}/Details/{id:int}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        try
        {
            return View(new IntranetViewModel
            {
                Pages = await _pageLogic.GetAllSorted(),
                PageModel = await _pageLogic.GetById(id)
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get page details: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    public async Task<IActionResult> Create()
    {
        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IntranetViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _pageLogic.Create(model.PageModel);
            return RedirectToAction(nameof(Index));
        }

        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted(),
            PageModel = model.PageModel
        });
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            _logger.LogInformation("Null id passed to edit route.");
            return RedirectToAction(nameof(Error));
        }

        var model = await _pageLogic.GetById(id.Value);
        if (model == null)
        {
            _logger.LogInformation("No page found for {id}.", id.Value);
            return RedirectToAction(nameof(Error));
        }
        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted(),
            PageModel = model
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, IntranetViewModel model)
    {
        if (id != model.PageModel.Id)
        {
            return RedirectToAction(nameof(Error));
        }

        if (ModelState.IsValid)
        {
            await _pageLogic.Update(model.PageModel);
            return RedirectToAction(nameof(Index));
        }
        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted(),
            PageModel = model.PageModel
        });
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var model = await _pageLogic.GetById(id.Value);
            if (model == null)
            {
                return RedirectToAction(nameof(Error));
            }

            return View(new IntranetViewModel
            {
                Pages = await _pageLogic.GetAllSorted(),
                PageModel = model
            });
        }

        return RedirectToAction(nameof(Error));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _pageLogic.Inactivate(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Error()
    {
        return View("NotFound");
    }
}
