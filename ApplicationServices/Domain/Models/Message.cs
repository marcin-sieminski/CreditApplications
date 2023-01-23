namespace CreditApplications.ApplicationServices.Domain.Models;

public class Message
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime Created { get; set; }
    public virtual List<Role> RolesToDistribute { get; set; }

}