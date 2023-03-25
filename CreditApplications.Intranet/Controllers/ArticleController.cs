using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.Intranet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplications.Intranet.Controllers;

public class ArticleController : Controller
{
    private readonly ILogger<ArticleController> _logger;
    private readonly IArticleLogic _articleLogic;
    private readonly IPageLogic _pageLogic;

    public ArticleController(ILogger<ArticleController> logger, IArticleLogic logic, IPageLogic pageLogic)
    {
        _logger = logger;
        _articleLogic = logic;
        _pageLogic = pageLogic;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(new IntranetViewModel
            {
                Pages = await _pageLogic.GetAllSorted(),
                Articles = await _articleLogic.GetAll()
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get article: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    public async Task<IActionResult> Read(int? id)
    {
        try
        {
            var model = await _articleLogic.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(new IntranetViewModel
            {
                Pages = await _pageLogic.GetAllSorted(),
                ArticleModel = model
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get article: {e}");
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
                ArticleModel = await _articleLogic.GetById(id)
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get article details: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    public async Task<IActionResult> Create()
    {
        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted(),
            SelectLists = new SelectListsForIntranetViewModel(await _articleLogic.GetAvailablePages())
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IntranetViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _articleLogic.Create(model.ArticleModel);
            return RedirectToAction(nameof(Index));
        }

        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted(),
            ArticleModel = model.ArticleModel,
            SelectLists = new SelectListsForIntranetViewModel(await _articleLogic.GetAvailablePages())
        });
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            _logger.LogInformation("Null id passed to edit route.");
            return RedirectToAction(nameof(Error));
        }

        var model = await _articleLogic.GetById(id.Value);
        if (model == null)
        {
            _logger.LogInformation("No article found for {id}.", id.Value);
            return RedirectToAction(nameof(Error));
        }
        
        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted(),
            ArticleModel = model,
            SelectLists = new SelectListsForIntranetViewModel(await _articleLogic.GetAvailablePages())
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, IntranetViewModel model)
    {
        if (id != model.ArticleModel.Id)
        {
            return RedirectToAction(nameof(Error));
        }

        if (ModelState.IsValid)
        {
            await _articleLogic.Update(model.ArticleModel);
            return RedirectToAction(nameof(Index));
        }

        return View(new IntranetViewModel
        {
            Pages = await _pageLogic.GetAllSorted(),
            ArticleModel = model.ArticleModel
        });
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var model = await _articleLogic.GetById(id.Value);
            if (model == null)
            {
                return RedirectToAction(nameof(Error));
            }

            return View(new IntranetViewModel
            {
                Pages = await _pageLogic.GetAllSorted(),
                ArticleModel = model
            });
        }

        return RedirectToAction(nameof(Error));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _articleLogic.Inactivate(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Error()
    {
        return View("NotFound");
    }
}