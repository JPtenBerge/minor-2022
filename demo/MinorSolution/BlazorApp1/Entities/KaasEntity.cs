using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Entities;

public class KaasEntity
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Vul naam in aub")]
    [RegularExpression("^[a-zA-Z]{1}[a-zA-Z -]*$", ErrorMessage = "Alleen letters, cijfers en verder niks graag")]
    public string Naam { get; set; }

    [Required]
    public string Geur { get; set; }

    [Required]
    public string ImageUrl { get; set; }
}