using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class CreditApplication
{
    public int Id { get; set; }
    public DateTime DateOfSubmission { get; set; }
    public int CustomerId { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string ProductTypeName { get; set; }
    public int ProductTypeId { get; set; }
    public string Currency { get; set; }
    public decimal AmountRequested { get; set; }
    public decimal AmountGranted { get; set; }
    public string ApplicationStatus { get; set; }
    public int ApplicationStatusId { get; set; }
    public DateTime DateOfLastStatusChange { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public int EmployeeId { get; set; }
    public string Notes { get; set; }
    public bool IsActive { get; set; }
    public List<CreditApplications.DataAccess.Entities.Customer> AvailableCustomers { get; set; } = new();
    public List<ProductType> AvailableProductTypes { get; set; } = new();
    public List<ApplicationStatus> AvailableApplicationStatuses { get; set; } = new();
    public List<Employee> AvailableEmployees { get; set; } = new();

}
