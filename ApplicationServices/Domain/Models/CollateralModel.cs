using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class CollateralModel
{
    [DisplayName("Id")] public int Id { get; set; }

    [DisplayName("Name")]
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }

    [DisplayName("Description")]
    [MaxLength(1000)]
    public string Description { get; set; }

    [DisplayName("Value")]
    [Range(0, 100000000)]
    [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
    public decimal? Value { get; set; }
}
