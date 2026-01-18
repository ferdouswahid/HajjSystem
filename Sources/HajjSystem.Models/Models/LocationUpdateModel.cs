using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class LocationUpdateModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }
}
