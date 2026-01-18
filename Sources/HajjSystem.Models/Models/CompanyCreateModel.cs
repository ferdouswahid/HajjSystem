using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class CompanyCreateModel
{
    [Required]
    public string CompanyName { get; set; } = string.Empty;
    
    public string CompanyNameAr { get; set; } = string.Empty;
    
    [Required]
    public string CrNumber { get; set; } = string.Empty;
    
    public string Address { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string VatRegNumber { get; set; } = string.Empty;
    public string BuildingNumber { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
