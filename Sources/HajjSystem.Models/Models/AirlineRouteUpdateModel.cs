using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class AirlineRouteUpdateModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Iata { get; set; }
    
    public string? Lat { get; set; }
    
    public string? Lon { get; set; }
    
    public string? Iso { get; set; }
    
    public bool? Status { get; set; }
    
    public string? Name { get; set; }
    
    public string? Continent { get; set; }
    
    public string? Type { get; set; }
    
    public string? Size { get; set; }
}
