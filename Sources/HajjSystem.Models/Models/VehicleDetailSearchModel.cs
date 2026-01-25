using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleDetailSearchModel
{
    public int? Id { get; set; }
    public int[]? Ids { get; set; }
    public int? VehicleId { get; set; }
    public int? RouteFromId { get; set; }
    public int? RouteToId { get; set; }
    public TripType? TripType { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public DateTime? DepartureDate { get; set; }
    public int? CompanyId { get; set; }
}
