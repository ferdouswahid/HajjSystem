using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities;

public class Vendor : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string? NameAr { get; set; }
    [Required]
    public VendorType Type { get; set; }
    public string? CrNumber { get; set; }
    public string? Address { get; set; }
    public string? Mobile { get; set; }
    public string? VatRegNumber { get; set; }
    public string? BuildingNumber { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Status { get; set; }

    [Required]
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
    
    public ICollection<Vehicle>? Vehicles { get; set; }
    public ICollection<Contract>? Contracts { get; set; }
    public ICollection<AirlineContract>? AirlineContracts { get; set; }
}
