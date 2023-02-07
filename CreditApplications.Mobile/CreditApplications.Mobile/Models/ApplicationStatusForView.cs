using System;
using System.ComponentModel;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Models;

public class ApplicationStatusForView : IEquatable<ApplicationStatusForView>
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Product type")]
    public string ApplicationStatusName { get; set; }
    

    public ApplicationStatusForView()
    {
        
    }

    public ApplicationStatusForView(ApplicationStatusModel model)
    {
        Id = model.Id;
        ApplicationStatusName = model.ApplicationStatusName;
    }

    public bool Equals(ApplicationStatusForView other)
    {
        if (other == null) return false;
        return (this.Id.Equals(other.Id));
    }

}