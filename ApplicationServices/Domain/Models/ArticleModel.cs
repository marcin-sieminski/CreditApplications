using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class ArticleModel
{
    public int Id { get; set; }

    [Display(Name = "Tytuł artykułu")]
    [Required(ErrorMessage = "Tytuł artykułu jest wymagany")]
    [MaxLength(5000, ErrorMessage = "Maksymalna długość to 5000 znaków")]
    public string Title { get; set; }

    [Display(Name = "Treść artykułu")]
    [Required(ErrorMessage = "Treść artykułu jest wymagana")]
    public string Body { get; set; }

    [Display(Name = "Tytuł odnośnika")]
    [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")]
    [MaxLength(1000, ErrorMessage = "Maksymalna długość to 1000 znaków")]
    public string LinkTitle { get; set; }

    [Display(Name = "Pozycja artykułu")]
    [Required(ErrorMessage = "Pozycja artykułu jest wymagana")]
    public int Position { get; set; }

    [Display(Name = "Artykuł utworzony")]
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }

    [Display(Name = "Strona")]
    [Required(ErrorMessage = "Strona jest wymagana")]
    public int PageId { get; set; }

    public virtual PageModel Page { get; set; }
}