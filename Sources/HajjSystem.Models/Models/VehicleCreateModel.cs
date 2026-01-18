using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleCreateModel
{
    public string? EngineNumber { get; set; }
    
    public string? ChassisNumber { get; set; }
    
    public string? Color { get; set; }
    
    public string? Model { get; set; }
    
    public int Year { get; set; }
    
    [Required]
    public string LicensePlate { get; set; }
    
    [Required]
    public VehicleType VehicleType { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int TotalSeat { get; set; }
    
    public string? Features { get; set; }
    
    public string? Status { get; set; }
    
    public int? CompanyId { get; set; }
    
    public int? VendorId { get; set; }
    
    public List<VehicleDetailCreateModel>? VehicleDetails { get; set; }
}
