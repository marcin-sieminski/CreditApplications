using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.Intranet.ViewModels;

public class HomePageViewModel
{
    public IEnumerable<ArticleModel> Articles { get; set; }
    public IEnumerable<PageModel> Pages { get; set; }
}
