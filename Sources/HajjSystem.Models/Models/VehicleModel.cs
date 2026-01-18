using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleModel
{
    public int Id { get; set; }
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
    public int TotalSeat { get; set; }
    public string? Features { get; set; }
    public string? Status { get; set; }
    public int? CompanyId { get; set; }
    public CompanyModel? Company { get; set; }
    public int? VendorId { get; set; }
    public VendorModel? Vendor { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEnabled { get; set; }

    public List<VehicleDetailModel>? VehicleDetails { get; set; }
}
