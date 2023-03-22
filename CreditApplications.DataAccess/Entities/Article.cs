using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Article : EntityBase
{
    [Required] public string Title { get; set; }
    [Required] public string Body { get; set; }

    [Required]
    public string LinkTitle { get; set; }

    public int Position { get; set; }
    public virtual List<Role> RolesToDistribute { get; set; }
}