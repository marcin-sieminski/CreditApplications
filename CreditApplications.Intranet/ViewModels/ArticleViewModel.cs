using CreditApplications.ApplicationServices.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditApplications.Intranet.ViewModels;

public class ArticleViewModel
{
    public ArticleModel? ArticleModel { get; set; }
    public List<SelectListItem>? AvailablePagesSelectList { get; set; }

    public ArticleViewModel()
    {
        
    }

    public ArticleViewModel(IEnumerable<PageModel> pageModels)
    {
        ArticleModel = new ArticleModel();
        AvailablePagesSelectList = SetAvailablePagesSelectList(pageModels);
    }

    private List<SelectListItem> SetAvailablePagesSelectList(IEnumerable<PageModel> pageModels)
    {
        var returnList = new List<SelectListItem> { new("None", "") };
        var availableList = pageModels.Select(x => new SelectListItem($"{x.LinkTitle}", x.Id.ToString())).ToList();
        returnList.AddRange(availableList);
        return returnList;
    }
}