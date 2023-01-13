using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; }
        public string? InactivatedBy { get; set; }
        public DateTime Inactivated { get; set; }
    }
