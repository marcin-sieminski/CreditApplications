using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.Intranet.ViewModels;

public class HomePageViewModel
{
    public IEnumerable<ArticleModel> Articles { get; set; }
}
