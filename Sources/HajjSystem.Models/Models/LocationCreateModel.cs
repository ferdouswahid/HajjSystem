using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class LocationCreateModel
{
    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }
}
