using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities
{
    public class Collateral : EntityBase
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        
        [MaxLength(1000)]
        public string Description { get; set; }
        
        public decimal? Value { get; set; }

        public virtual List<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();
    }
}
