using System.ComponentModel.DataAnnotations.Schema;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities;

public class VehicleDetail : BaseEntity
{
    public int VehicleId { get; set; }
    [ForeignKey("VehicleId")]
    public Vehicle? Vehicle { get; set; }
    
    public int RouteFromId { get; set; }
    [ForeignKey("RouteFromId")]
    public VehicleRoute? RouteFrom { get; set; }
    
    public int RouteToId { get; set; }
    [ForeignKey("RouteToId")]
    public VehicleRoute? RouteTo { get; set; }
    
    public TripType TripType { get; set; }
    public decimal Price { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime? ArrivalDate { get; set; }
    
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
}
