using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class MealTypeCreateModel
{
    [Required]
    public string Name { get; set; }
    
    public string? Detail { get; set; }
}
