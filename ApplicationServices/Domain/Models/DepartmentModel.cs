using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class DepartmentModel
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Department name")]
    [Required]
    [MaxLength(100)]
    public string DepartmentName { get; set; }
}