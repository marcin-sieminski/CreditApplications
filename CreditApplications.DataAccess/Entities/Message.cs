namespace CreditApplications.DataAccess.Entities;

public class Message : EntityBase
{
    public string Title { get; set; }
    public string Body { get; set; }
    public virtual List<Role> RolesToDistribute { get; set; }

}