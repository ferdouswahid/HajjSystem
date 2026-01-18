using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class VendorModel
{
    public int Id { get; set; }
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
    public CompanyModel? Company { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEnabled { get; set; }
}
