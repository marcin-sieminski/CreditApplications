using System.ComponentModel.DataAnnotations;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class Role
{
    public string RoleName { get; set; }

    public virtual List<Employee> Employees { get; set; } = new List<Employee>();
}
