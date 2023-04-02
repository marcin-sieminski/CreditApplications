using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CreditApplications.DataAccess.Entities;

public class Article : EntityBase
{
    [Required] 
    public string Title { get; set; }
    
    [Required] 
    public string Body { get; set; }

    [Required]
    public string LinkTitle { get; set; }

    [Required]
    public int Position { get; set; }
    
    [Required]
    public int PageId { get; set; }
    
    public virtual Page Page { get; set; }

    public IdentityUser CreatedBy { get; set; }
}