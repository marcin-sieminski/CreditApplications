using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Page : EntityBase
{

    [Required]
    public string Title { get; set; }
    
    public string Body { get; set; }

    [Required]
    public string LinkTitle { get; set; }

    [Required]
    public int Position { get; set; }
    
    public virtual List<Article> Articles { get; set; }
}