using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CreditApplications.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using CreditApplicationModel = CreditApplications.ApplicationServices.Domain.Models.CreditApplicationModel;

namespace CreditApplications.Intranet.ViewModels;

public class CreditApplicationViewModel
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Customer")]
    public int CustomerId { get; set; }

    [DisplayName("Customer first name")]
    public string CustomerFirstName { get; set; }

    [DisplayName("Customer last name")]
    public string CustomerLastName { get; set; }


    [DisplayName("Customer name")]
    public string CustomerFullName { get; set; }

    public List<SelectListItem> AvailableCustomersSelectList { get; set; } = new();

    public int ProductTypeId { get; set; }

    [DisplayName("Product type")]
    public string ProductTypeName { get; set; }

    public List<SelectListItem> AvailableProductTypesSelectList { get; set; } = new();

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
    public int ApplicationStatusId { get; set; }
    public string ApplicationStatus { get; set; }

    public List<SelectListItem> AvailableApplicationStatusesSelectList { get; set; } = new();

    [DisplayName("Last status change")]
    public DateTime DateOfLastStatusChange { get; set; }

    [DisplayName("Employee")]
    public int EmployeeId { get; set; }

    [DisplayName("Employee first name")]
    public string EmployeeFirstName { get; set; }

    [DisplayName("Employee last name")]
    public string EmployeeLastName { get; set; }

    public List<SelectListItem> AvailableEmployeesSelectList { get; set; } = new();


    [DisplayName("Notes")]
    public string Notes { get; set; }

    public List<CreditApplications.DataAccess.Entities.Customer> AvailableCustomers { get; set; } = new();
    public List<ProductType> AvailableProductTypes { get; set; } = new();
    public List<ApplicationStatus> AvailableApplicationStatuses { get; set; } = new();
    public List<Employee> AvailableEmployees { get; set; } = new();

    public void Initialize()
    {
        AvailableCustomersSelectList = GetAvailableCustomers();
        AvailableProductTypesSelectList = GetAvailableProductTypes();
        AvailableApplicationStatusesSelectList = GetAvailableApplicationStatuses();
        AvailableEmployeesSelectList = GetAvailableEmployees();
    }

    private List<SelectListItem> GetAvailableEmployees()
    {
        var returnList = new List<SelectListItem> { new("None", "") };
        var availableList = AvailableEmployees.Select(x => new SelectListItem($"{x.FirstName} {x.LastName}", x.Id.ToString())).ToList();
        returnList.AddRange(availableList);
        return returnList;
    }

    private List<SelectListItem> GetAvailableApplicationStatuses()
    {
        var returnList = new List<SelectListItem> { new("None", "") };
        var availableList = AvailableApplicationStatuses.Select(x => new SelectListItem(x.ApplicationStatusName, x.Id.ToString())).ToList();
        returnList.AddRange(availableList);
        return returnList;
    }

    private List<SelectListItem> GetAvailableProductTypes()
    {
        var returnList = new List<SelectListItem> { new("None", "") };
        var availableList = AvailableProductTypes.Select(x => new SelectListItem(x.ProductTypeName, x.Id.ToString())).ToList();
        returnList.AddRange(availableList);
        return returnList;
    }

    private List<SelectListItem> GetAvailableCustomers()
    {
        var returnList = new List<SelectListItem> { new("None", "") };
        var availableList = AvailableCustomers.Select(x => new SelectListItem($"{x.CustomerFirstName} {x.CustomerLastName}", x.Id.ToString())).ToList();
        returnList.AddRange(availableList);
        return returnList;
    }

    public CreditApplicationViewModel()
    {

    }

    public CreditApplicationViewModel(CreditApplicationModel model)
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
        AvailableCustomers = model.AvailableCustomers;
        AvailableProductTypes = model.AvailableProductTypes;
        AvailableApplicationStatuses = model.AvailableApplicationStatuses;
        AvailableEmployees = model.AvailableEmployees;
        CustomerId = model.CustomerId;
        EmployeeId = model.EmployeeId;
        ProductTypeId = model.ProductTypeId;
        ApplicationStatusId = model.ApplicationStatusId;
    }

    public CreditApplicationViewModel PrepareViewModel(CreditApplicationViewModel model)
    {
        return new CreditApplicationViewModel
        {
            Id = model.Id,
            DateOfSubmission = model.DateOfSubmission,
            CustomerFirstName = model.CustomerFirstName,
            CustomerLastName = model.CustomerLastName,
            CustomerFullName = $"{model.CustomerFirstName} {model.CustomerLastName}",
            ProductTypeName = model.ProductTypeName,
            Currency = model.Currency,
            AmountRequested = model.AmountRequested,
            AmountGranted = model.AmountGranted,
            ApplicationStatus = model.ApplicationStatus,
            DateOfLastStatusChange = model.DateOfLastStatusChange,
            EmployeeFirstName = model.EmployeeFirstName,
            EmployeeLastName = model.EmployeeLastName,
            Notes = model.Notes,
            AvailableCustomers = model.AvailableCustomers,
            AvailableProductTypes = model.AvailableProductTypes,
            AvailableApplicationStatuses = model.AvailableApplicationStatuses,
            AvailableEmployees = model.AvailableEmployees,
            CustomerId = model.CustomerId,
            ProductTypeId = model.ProductTypeId,
            EmployeeId = model.EmployeeId,
            ApplicationStatusId = model.ApplicationStatusId
        };
    }

    public CreditApplicationModel ToModel()
    {
        return new CreditApplicationModel
        {
            Id = Id,
            DateOfSubmission = DateOfSubmission,
            ProductTypeName = ProductTypeName,
            Currency = Currency,
            AmountRequested = AmountRequested,
            AmountGranted = AmountGranted,
            ApplicationStatus = ApplicationStatus,
            DateOfLastStatusChange = DateOfLastStatusChange,
            Notes = Notes,
            CustomerId = CustomerId,
            ProductTypeId = ProductTypeId,
            ApplicationStatusId = ApplicationStatusId
        };
    }
}