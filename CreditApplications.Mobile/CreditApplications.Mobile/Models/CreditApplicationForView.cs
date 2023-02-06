using System;
using System.ComponentModel;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Models;

public class CreditApplicationForView
{
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [DisplayName("Customer")]
    public int CustomerId { get; set; }
    
    [DisplayName("First name")]
    public string CustomerFirstName { get; set; }
    [DisplayName("Last name")]
    
    public string CustomerLastName { get; set; }

    [DisplayName("Product type")]
    public int ProductTypeId { get; set; }
    
    [DisplayName("Product type")]
    public string ProductTypeName { get; set; }
    
    [DisplayName("Currency")]
    public string Currency { get; set; }
    
    [DisplayName("Amount requested")]
    public decimal AmountRequested { get; set; }
    
    [DisplayName("Amount granted")]
    public decimal AmountGranted { get; set; }
    
    [DisplayName("Application status")] 
    public int ApplicationStatusId { get; set; }

    [DisplayName("Application status")]
    public string ApplicationStatus { get; set; }
    
    [DisplayName("Date of submission")]
    public DateTime DateOfSubmission { get; set; }
    
    [DisplayName("Date of status change")]
    public DateTime DateOfLastStatusChange { get; set; }
    
    [DisplayName("Employee")] public int EmployeeId { get; set; }

    [DisplayName("Employee first name")]
    public string EmployeeFirstName { get; set; }
    
    [DisplayName("Employee first name")]
    public string EmployeeLastName { get; set; }
    
    [DisplayName("Notes")]
    public string Notes { get; set; }

    public CreditApplicationForView()
    {
        
    }

    public CreditApplicationForView(CreditApplicationModel model)
    {
        Id = model.Id;
        CustomerId = model.CustomerId;
        CustomerFirstName = model.CustomerFirstName;
        CustomerLastName = model.CustomerLastName;
        ProductTypeId = model.ProductTypeId;
        ProductTypeName = model.ProductTypeName;
        Currency = model.Currency;
        AmountRequested = model.AmountRequested;
        AmountGranted = model.AmountGranted;
        ApplicationStatus = model.ApplicationStatus;
        DateOfSubmission = model.DateOfSubmission;
        DateOfLastStatusChange = model.DateOfLastStatusChange;
        EmployeeId = model.EmployeeId;
        EmployeeFirstName = model.EmployeeFirstName;
        EmployeeLastName = model.EmployeeLastName;
        Notes = model.Notes;
    }
}
