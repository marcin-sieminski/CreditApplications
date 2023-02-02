using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class ApplicationStatusModel
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Application status")]
    [Required]
    [MaxLength(100)]
    public string ApplicationStatusName { get; set; }
}