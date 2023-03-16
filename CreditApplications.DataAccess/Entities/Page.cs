using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Page : EntityBase
{
    [Required]
    public string LinkTitle { get; set; }

    [Required]
    public string Title { get; set; }
    
    public string Body { get; set; }

    public int Position { get; set; }
}