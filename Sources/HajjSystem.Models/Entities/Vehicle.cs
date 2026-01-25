using System.ComponentModel.DataAnnotations.Schema;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities;

public class Vehicle : BaseEntity
{
    public string? EngineNumber { get; set; }

    public string? ChassisNumber { get; set; }

    public string? Color { get; set; }

    public string? Model { get; set; }
    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public int TotalSeat { get; set; }
    public string? Features { get; set; }
    public string? Status { get; set; }
    
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
    
    public int VendorId { get; set; }
    [ForeignKey("VendorId")]
    public Vendor? Vendor { get; set; }
    
    public ICollection<VehicleContract> VehicleContracts { get; set; }
    public ICollection<VehicleDetail> VehicleDetails { get; set; }
}

