using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class ArticleModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Article link title is required")]
    [MaxLength(200, ErrorMessage = "Max article link title is 200 characters")]
    [Display(Name = "Article link title")]
    public string LinkTitle { get; set; }

    [Required(ErrorMessage = "Article title is required")]
    [MaxLength(30, ErrorMessage = "Max article  title is 1000 characters")]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Display(Name = "Body")]
    [Column(TypeName = "nvarchar(MAX)")]
    public string Body { get; set; }

    [Display(Name = "Position")]
    [Required(ErrorMessage = "Position is required")]
    public int Position { get; set; }
}