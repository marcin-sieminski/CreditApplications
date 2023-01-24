namespace CreditApplications.ApplicationServices.Domain.Models;

public class MessageModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime Created { get; set; }
    public virtual List<RoleModel> RolesToDistribute { get; set; }

}