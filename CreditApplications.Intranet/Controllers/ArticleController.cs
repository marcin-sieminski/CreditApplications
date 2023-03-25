using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.ApplicationServices.Domain.Models;
using CreditApplications.Intranet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplications.Intranet.Controllers;

public class ArticleController : Controller
{
    private readonly ILogger<ArticleController> _logger;
    private readonly IArticleLogic _logic;

    public ArticleController(ILogger<ArticleController> logger, IArticleLogic logic)
    {
        _logger = logger;
        _logic = logic;
    }

    public async Task<IActionResult> Index(int? id)
    {
        try
        {
            var model = await _logic.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get article: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    public async Task<IActionResult> List()
    {
        try
        {
            var model = await _logic.GetAll();
            return View(model);
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
            var model = await _logic.GetById(id);
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get article details: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    public async Task<IActionResult> Create()
    {
        var viewModel = new ArticleViewModel(await _logic.GetAvailablePages());
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ArticleViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _logic.Create(viewModel.ArticleModel);
            return RedirectToAction(nameof(List));
        }
        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            _logger.LogInformation("Null id passed to edit route.");
            return RedirectToAction(nameof(Error));
        }

        var model = await _logic.GetById(id.Value);
        if (model == null)
        {
            _logger.LogInformation("No article found for {id}.", id.Value);
            return RedirectToAction(nameof(Error));
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ArticleModel model)
    {
        if (id != model.Id)
        {
            return RedirectToAction(nameof(Error));
        }

        if (ModelState.IsValid)
        {
            await _logic.Update(model);
            return RedirectToAction(nameof(List));
        }
        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            var model = await _logic.GetById(id.Value);
            if (model == null)
            {
                return RedirectToAction(nameof(Error));
            }

            return View(model);
        }

        return RedirectToAction(nameof(Error));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _logic.Inactivate(id);
        return RedirectToAction(nameof(List));
    }

    public IActionResult Error()
    {
        return View("NotFound");
    }
}