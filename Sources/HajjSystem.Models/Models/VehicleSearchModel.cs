using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VehicleSearchModel
{
    public int? Id { get; set; }
    public int[]? Ids { get; set; }
    public string? EngineNumber { get; set; }
    public string? ChassisNumber { get; set; }
    public string? Color { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? LicensePlate { get; set; }
    public VehicleType? VehicleType { get; set; }
    public int? TotalSeat { get; set; }
    public string? Features { get; set; }
    public string? Status { get; set; }
    public int CompanyId { get; set; }

    public int? VendorId { get; set; }
}
