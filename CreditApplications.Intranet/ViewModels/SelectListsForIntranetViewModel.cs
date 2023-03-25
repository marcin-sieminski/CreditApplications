using CreditApplications.ApplicationServices.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditApplications.Intranet.ViewModels;

public class SelectListsForIntranetViewModel
{
    public List<SelectListItem>? AvailablePagesSelectList { get; set; }

    public SelectListsForIntranetViewModel()
    {
        
    }

    public SelectListsForIntranetViewModel(IEnumerable<PageModel> pageModels)
    {
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