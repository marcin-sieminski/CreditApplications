using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.Web.ViewModels;

public class CreditApplicationViewModel
{
    public int Id { get; set; }
    public DateTime DateOfSubmission { get; set; }
    public int CustomerId { get; set; }
    public string CustomerFullName { get; set; }
    public string ProductTypeName { get; set; }
    public string Currency { get; set; }
    public decimal AmountRequested { get; set; }
    public decimal AmountGranted { get; set; }
    public string ApplicationStatus { get; set; }
    public DateTime DateOfLastStatusChange { get; set; }
    public string EmployeeFullName { get; set; }
    public string Notes { get; set; }

    public static CreditApplicationViewModel FromModel(CreditApplication model)
    {
        return new CreditApplicationViewModel
        {
            Id = model.Id,
            DateOfSubmission = model.DateOfSubmission,
            CustomerFullName = $"{model.CustomerFirstName} {model.CustomerLastName}",
            ProductTypeName = model.ProductTypeName,
            Currency = model.Currency,
            AmountRequested = model.AmountRequested,
            AmountGranted = model.AmountGranted,
            ApplicationStatus = model.ApplicationStatus,
            DateOfLastStatusChange = model.DateOfLastStatusChange,
            EmployeeFullName = $"{model.EmployeeFirstName} {model.EmployeeLastName}",
            Notes = model.Notes
        };
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