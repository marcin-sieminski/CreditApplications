using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class ProductType : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string? ProductTypeName { get; set; }

    public List<CreditApplication>? CreditApplications { get; set; }
}
