using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.Web.ViewModels;

public class CreditApplicationListViewModel
{
    public List<CreditApplicationViewModel> CreditApplications { get; set; } = new List<CreditApplicationViewModel>();
}
