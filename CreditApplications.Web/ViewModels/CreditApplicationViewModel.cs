using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.Web.ViewModels;

public class CreditApplicationViewModel
{
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [DisplayName("Submission")]
    [Required(ErrorMessage = "Please provide date of submission.")]
    public DateTime DateOfSubmission { get; set; }
    
    public int CustomerId { get; set; }
    
    [DisplayName("Customer first name")]
    public string CustomerFirstName { get; set; }
    
    [DisplayName("Customer last name")]
    public string CustomerLastName { get; set; }
    
    
    [DisplayName("Customer name")]
    public string CustomerFullName { get; set; }
    
    
    [DisplayName("Product type")]
    public string ProductTypeName { get; set; }
    
    public string Currency { get; set; }
    
    [DisplayName("Amount requested")]
    [Required]
    [DataType(DataType.Currency)]
    [Range(0.00, 100000000.00, ErrorMessage = "Value for {0} must be between {1:C} and {2:C}")]
    public decimal AmountRequested { get; set; }
    
    [DisplayName("Amount granted")]
    [Required]
    [DataType(DataType.Currency)]
    [Range(0.00, 100000000.00, ErrorMessage = "Value for {0} must be between {1:C} and {2:C}")]
    public decimal AmountGranted { get; set; }
    
    [DisplayName("Status")]
    public string ApplicationStatus { get; set; }
    
    [DisplayName("Last status change")]
    public DateTime DateOfLastStatusChange { get; set; }
    
    [DisplayName("Employee first name")]
    public string EmployeeFirstName { get; set; }
    
    [DisplayName("Employee last name")]
    public string EmployeeLastName { get; set; }
    
    [DisplayName("Nones")] 
    public string Notes { get; set; }


    public CreditApplicationViewModel(CreditApplication model)
    {
        Id = model.Id;
        DateOfSubmission = model.DateOfSubmission;
        CustomerFirstName = model.CustomerFirstName;
        CustomerLastName = model.CustomerLastName;
        CustomerFullName = $"{model.CustomerFirstName} {model.CustomerLastName}";
        ProductTypeName = model.ProductTypeName;
        Currency = model.Currency;
        AmountRequested = model.AmountRequested;
        AmountGranted = model.AmountGranted;
        ApplicationStatus = model.ApplicationStatus;
        DateOfLastStatusChange = model.DateOfLastStatusChange;
        EmployeeFirstName = model.EmployeeFirstName;
        EmployeeLastName = model.EmployeeLastName;
        Notes = model.Notes;
    }

    public CreditApplication ToModel()
    {
        return new CreditApplication
        {
            Id = Id,
            DateOfSubmission = DateOfSubmission,
            ProductTypeName = ProductTypeName,
            Currency = Currency,
            AmountRequested = AmountRequested,
            AmountGranted = AmountGranted,
            ApplicationStatus = ApplicationStatus,
            DateOfLastStatusChange = DateOfLastStatusChange,
            Notes = Notes
        };
    }
}