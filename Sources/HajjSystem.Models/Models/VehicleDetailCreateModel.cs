using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleDetailCreateModel
{
    [Required]
    public int RouteFromId { get; set; }
    
    [Required]
    public int RouteToId { get; set; }
    
    [Required]
    public TripType TripType { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
    
    [Required]
    public DateTime DepartureDate { get; set; }
    
    public DateTime? ArrivalDate { get; set; }
    
    [Required]
    public int CompanyId { get; set; }
}
