using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class PageModel
{
    public int Id { get; set; }


    [Display(Name = "Tytuł strony")]
    [Required(ErrorMessage = "Tytuł strony jest wymagany")]
    [MaxLength(1000, ErrorMessage = "Maksymalna długość to 1000 znaków")]
    public string Title { get; set; }

    [Display(Name = "Opis strony")]
    [Column(TypeName = "nvarchar(MAX)")]
    public string Description { get; set; }

    [Display(Name = "Tytuł odnośnika do strony")]
    [Required(ErrorMessage = "Tytuł odnośnika do strony jest wymagany")]
    [MaxLength(200, ErrorMessage = "Maksymalna długość to 200 znaków")]
    public string LinkTitle { get; set; }

    [Display(Name = "Pozycja strony")]
    [Required(ErrorMessage = "Pozycja strony jest wymagana")]
    public int Position { get; set; }
    public bool IsActive { get; set; }

    public virtual IEnumerable<ArticleModel> Articles { get; set; }
}