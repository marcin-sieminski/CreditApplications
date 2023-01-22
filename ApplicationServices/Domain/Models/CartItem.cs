using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class CartItem
{
    public int Id { get; set; }
    public string SessionId { get; set; }
    
    [DisplayName("Application Id")]
    public int CreditApplicationId { get; set; }
    public virtual DataAccess.Entities.CreditApplication CreditApplication { get; set; }
        
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public virtual Employee Employee { get; set; }

    [DisplayName("Date added to cart")]
    public DateTime Created { get; set; }
}