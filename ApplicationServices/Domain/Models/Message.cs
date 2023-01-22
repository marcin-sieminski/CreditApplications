namespace CreditApplications.ApplicationServices.Domain.Models;

public class Message
{
    public string Title { get; set; }
    public string Body { get; set; }
    public virtual List<Role> RolesToDistribute { get; set; }

}