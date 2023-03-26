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
    [Required(ErrorMessage = "Article body is required")]
    public string Body { get; set; }

    [Required(ErrorMessage = "Link title is required")]
    [MaxLength(200, ErrorMessage = "Max title length is 200 characters")]
    [Display(Name = "Link title")]
    public string LinkTitle { get; set; }

    [Display(Name = "Position")]
    [Required(ErrorMessage = "Position is required")]
    public int Position { get; set; }

    [Display(Name = "Created")]
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }

    [Display(Name = "Page")]
    [Required(ErrorMessage = "Page is required")]
    public int PageId { get; set; }
}