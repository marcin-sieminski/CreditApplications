using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.Intranet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplications.Intranet.Controllers;

[Authorize]
public class IntranetController : Controller
{
    private readonly ILogger<ArticleController> _logger;
    private readonly IPageLogic _pageLogic;
    private readonly IArticleLogic _articleLogic;

    public IntranetController(ILogger<ArticleController> logger, IPageLogic pageLogic, IArticleLogic articleLogic)
    {
        _logger = logger;
        _pageLogic = pageLogic;
        _articleLogic = articleLogic;
    }

    public async Task<IActionResult> List(int? id)
    {
        try
        {
            return View(new IntranetViewModel
            {
                Articles = await _articleLogic.GetByPageIdSorted(id),
                Pages = await _pageLogic.GetAllSorted()
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to get intranet content count: {e}");
            return RedirectToAction(nameof(Error));
        }

    }
    
    public async Task<IActionResult> Read(int? id, int? articleId)
    {
        try
        {
            var model = await _articleLogic.GetById(articleId.Value);
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
            _logger.LogError($"Failed to get intranet items: {e}");
            return RedirectToAction(nameof(Error));
        }
    }

    public IActionResult Error()
    {
        return View("NotFound");
    }
}