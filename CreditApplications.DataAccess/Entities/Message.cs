using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Message : EntityBase
{
    [Required] public string Title { get; set; }
    [Required] public string Body { get; set; }
    public virtual List<Role> RolesToDistribute { get; set; }

}