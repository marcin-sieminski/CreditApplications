using System.ComponentModel.DataAnnotations;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class RoleModel
{
    public string RoleName { get; set; }

    public virtual List<Employee> Employees { get; set; } = new List<Employee>();
}
