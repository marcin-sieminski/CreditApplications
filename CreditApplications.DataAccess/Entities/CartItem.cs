using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditApplications.DataAccess.Entities
{
    public class CartItem : EntityBase
    {
        public string SessionId { get; set; }

        public int CreditApplicationId { get; set; }
        [ForeignKey("CreditApplicationId")]
        public virtual CreditApplication CreditApplication { get; set; }
        
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
