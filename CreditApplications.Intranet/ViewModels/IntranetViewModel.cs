using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.Intranet.ViewModels;

public class IntranetViewModel
{
    public IEnumerable<ArticleModel>? Articles { get; set; }
    public IEnumerable<PageModel>? Pages { get; set; }
    public ArticleModel? ArticleModel { get; set; }
    public PageModel? PageModel { get; set; }
    public SelectListsForIntranetViewModel? SelectLists { get; set; }
}
