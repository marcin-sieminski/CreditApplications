using CreditApplications.DataAccess.Entities;

namespace CreditApplications.Intranet.ViewModels;

public class HomePageViewModel
{
    public int ActiveCreditApplicationsNumber { get; set; }
    public int MyCreditApplicationsNumber { get; set; } 
    public int CustomersCount { get; set; }
    public IEnumerable<Message> Messages { get; set; }
}
