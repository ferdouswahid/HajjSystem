using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class MealTypeUpdateModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string? Detail { get; set; }
}
