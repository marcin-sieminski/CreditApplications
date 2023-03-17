using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class ArticleModel
{
    public int Id { get; set; }
    
    [Display(Name = "Title")]
    [Required(ErrorMessage = "Article title is required")]
    [MaxLength(1000, ErrorMessage = "Max article title length is 1000 characters")]
    public string Title { get; set; }

    [Display(Name = "Body")]
    public string Body { get; set; }
    
    [Display(Name = "Position")]
    [Required(ErrorMessage = "Position is required")]
    public int Position { get; set; }

    public DateTime Created { get; set; }
    public virtual List<RoleModel> RolesToDistribute { get; set; }
}