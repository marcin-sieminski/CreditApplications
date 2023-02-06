using System.ComponentModel;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Models;

public class ApplicationStatusForView
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Product type")]
    public string ApplicationStatusName { get; set; }
    

    public ApplicationStatusForView()
    {
        
    }

    //public ApplicationStatusForView(ApplicationStatusModel model)
    //{
    //    Id = model.Id;
    //    ApplicationStatusName = model.ApplicationStatusName;
    //}
}