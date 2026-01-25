using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleDetailCreateModel
{
    public int? VehicleId { get; set; }

    //public VehicleModel? Vehicle { get; set; }


    [Required]
    public int RouteFromId { get; set; }

    //public VehicleRouteModel? RouteFrom { get; set; }
    
    [Required]
    public int RouteToId { get; set; }
    // public VehicleRouteModel? RouteTo { get; set; }
    
    [Required]
    public TripType TripType { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public DateTime DepartureDate { get; set; }
    
    public DateTime? ArrivalDate { get; set; }
    
    [Required]
    public int CompanyId { get; set; }
    //public CompanyModel? Company { get; set; }

    
}
