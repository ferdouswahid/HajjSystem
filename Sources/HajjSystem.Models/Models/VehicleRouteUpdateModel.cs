using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class VehicleRouteUpdateModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string? Details { get; set; }
    
    [Required]
    public int CompanyId { get; set; }
}
