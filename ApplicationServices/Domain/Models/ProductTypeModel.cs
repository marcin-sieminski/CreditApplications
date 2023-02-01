using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class ProductTypeModel
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Product type name")]
    [Required]
    [MaxLength(100)]
    public string ProductTypeName { get; set; }
}