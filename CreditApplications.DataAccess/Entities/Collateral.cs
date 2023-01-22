using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities
{
    public class Collateral : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        
        [MaxLength(5000)]
        public string Description { get; set; }
        
        public int? Value { get; set; }

        public virtual List<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();
    }
}
