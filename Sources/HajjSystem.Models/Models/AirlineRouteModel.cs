namespace HajjSystem.Models.Models;

public class AirlineRouteModel
{
    public int Id { get; set; }
    public string Iata { get; set; } = string.Empty;
    public string? Lat { get; set; }
    public string? Lon { get; set; }
    public string? Iso { get; set; }
    public bool? Status { get; set; }
    public string? Name { get; set; }
    public string? Continent { get; set; }
    public string? Type { get; set; }
    public string? Size { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
