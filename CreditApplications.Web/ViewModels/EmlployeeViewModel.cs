using CreditApplications.ApplicationServices.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditApplications.Web.ViewModels;

public class EmployeeViewModel
{
    public EmployeeModel EmployeeModel { get; set; }
    public List<SelectListItem> AvailableDepartmentsSelectList { get; set; }
    public List<SelectListItem> AvailableRolesSelectList { get; set; }

    public EmployeeViewModel()
    {
        
    }

    public EmployeeViewModel(EmployeeModel model)
    {
        EmployeeModel = model;
        AvailableDepartmentsSelectList = InitializeAvailableDepartmentsSelectList();
        AvailableRolesSelectList = InitializeAvailableRolesSelectList();
    }

    private List<SelectListItem> InitializeAvailableDepartmentsSelectList()
    {
        var returnList = new List<SelectListItem> { new("None", "") };
        var availableList = EmployeeModel.AvailableDepartments.Select(x => new SelectListItem($"{x.DepartmentName}", x.Id.ToString())).ToList();
        returnList.AddRange(availableList);
        return returnList;
    }

    private List<SelectListItem> InitializeAvailableRolesSelectList()
    {
        var returnList = new List<SelectListItem> { new("None", "") };
        var availableList = EmployeeModel.AvailableRoles.Select(x => new SelectListItem($"{x.RoleName}", x.Id.ToString())).ToList();
        returnList.AddRange(availableList);
        return returnList;
    }

}