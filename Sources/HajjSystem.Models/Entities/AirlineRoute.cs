namespace HajjSystem.Models.Entities;

public class AirlineRoute : BaseEntity
{
    public string Iata { get; set; }
    public string? Lat { get; set; }
    public string? Lon { get; set; }
    public string? Iso { get; set; }
    public bool? Status { get; set; }
    public string? Name { get; set; }
    public string? Continent { get; set; }
    public string? Type { get; set; }
    public string? Size { get; set; }
    
    public ICollection<AirlineContractDetail>? RouteFromDetails { get; set; }
    public ICollection<AirlineContractDetail>? RouteToDetails { get; set; }
}
