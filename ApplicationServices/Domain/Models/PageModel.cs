using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class PageModel
{
    public int Id { get; set; }


    [Display(Name = "Title")]
    [Required(ErrorMessage = "Page title is required")]
    [MaxLength(300, ErrorMessage = "Max page title length is 300 characters")]
    public string Title { get; set; }

    [Display(Name = "Body")]
    [Column(TypeName = "nvarchar(MAX)")]
    public string Body { get; set; }

    [Display(Name = "Link title")]
    [Required(ErrorMessage = "Link title is required")]
    [MaxLength(200, ErrorMessage = "Max title length is 200 characters")]
    public string LinkTitle { get; set; }

    [Display(Name = "Position")]
    [Required(ErrorMessage = "Position is required")]
    public int Position { get; set; }
    public bool IsActive { get; set; }

    public virtual IEnumerable<ArticleModel> Articles { get; set; }
}