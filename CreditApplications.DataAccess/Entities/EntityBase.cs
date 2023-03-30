using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public string CreatedById { get; set; }
        public DateTime? Created { get; set; }

        public string ModifiedById { get; set; }
        public DateTime? Modified { get; set; }

        public bool IsActive { get; set; }
        public string InactivatedById { get; set; }
        public DateTime? Inactivated { get; set; }
    }
