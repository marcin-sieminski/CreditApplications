using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class CreditApplicationModel
{
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [DisplayName("Customer")]
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    [DisplayName("Customer first name")]
    public string CustomerFirstName { get; set; }
    
    [DisplayName("Customer last name")]
    public string CustomerLastName { get; set; }
    
    [DisplayName("Product type")]
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; }
    
    [Required]
    [MinLength(3, ErrorMessage = "Currency must contain 3 letters.")]
    public string Currency { get; set; }

    [DisplayName("Amount requested")]
    [Required]
    [Range(0, 100000000, ErrorMessage = "Value for {0} must be between {1:C} and {2:C}")]
    [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
    public decimal AmountRequested { get; set; }
    
    [DisplayName("Amount granted")]
    [Required]
    [Range(0, 100000000, ErrorMessage = "Value for {0} must be between {1:C} and {2:C}")]
    [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
    public decimal AmountGranted { get; set; }
    
    [DisplayName("Submission")]
    [Required(ErrorMessage = "Please provide date of submission.")]
    public DateTime DateOfSubmission { get; set; } = DateTime.Now;
    
    [DisplayName("Status")]
    public string ApplicationStatus { get; set; }
    public int ApplicationStatusId { get; set; }
    
    [DisplayName("Last status change")]
    public DateTime DateOfLastStatusChange { get; set; }
    
    [DisplayName("Employee")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    [DisplayName("Employee first name")]
    public string EmployeeFirstName { get; set; }
    
    [DisplayName("Employee last name")]
    public string EmployeeLastName { get; set; }
    
    [DisplayName("Notes")]
    public string Notes { get; set; }
    public bool IsActive { get; set; }
    public List<CreditApplications.DataAccess.Entities.Customer> AvailableCustomers { get; set; } = new();
    public List<ProductType> AvailableProductTypes { get; set; } = new();
    public List<ApplicationStatus> AvailableApplicationStatuses { get; set; } = new();
    public List<Employee> AvailableEmployees { get; set; } = new();

}
