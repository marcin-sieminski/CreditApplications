using CreditApplications.ApplicationServices.Domain.Interfaces;
using CreditApplications.Intranet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplications.Intranet.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            try
            {
                return View(new HomePageViewModel
                {
                    Articles = await _articleLogic.GetAllSorted()
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get intranet content count: {e}");
                return RedirectToAction(nameof(Error));
            }

        }
        public IActionResult Error()
        {
            return View("NotFound");
        }
    }
}
