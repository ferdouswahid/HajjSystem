using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleUpdateModel
{
    [Required]
    public int Id { get; set; }
    
    public string? EngineNumber { get; set; }
    
    public string? ChassisNumber { get; set; }
    
    public string? Color { get; set; }
    
    public string? Model { get; set; }
    
    public int Year { get; set; }
    
    [Required]
    public string LicensePlate { get; set; } = string.Empty;
    
    [Required]
    public VehicleType VehicleType { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int TotalSeat { get; set; }
    
    public string? Features { get; set; }
    
    public string? Status { get; set; }
    
    public int CompanyId { get; set; }
    
    public int VendorId { get; set; }
    
    public List<VehicleDetailUpdateModel>? VehicleDetails { get; set; }
}
