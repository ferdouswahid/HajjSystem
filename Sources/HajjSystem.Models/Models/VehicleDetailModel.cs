using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleDetailModel
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public VehicleModel? Vehicle { get; set; }

    public int RouteFromId { get; set; }
    public VehicleRouteModel? RouteFrom { get; set; }
    public int RouteToId { get; set; }
    public VehicleRouteModel? RouteTo { get; set; }
    public TripType TripType { get; set; }
    public decimal Price { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime? ArrivalDate { get; set; }
    public int CompanyId { get; set; }
    public CompanyModel? Company { get; set; }
}
