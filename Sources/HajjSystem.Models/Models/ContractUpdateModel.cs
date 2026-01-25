using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class ContractUpdateModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public int VendorId { get; set; }
    
    [Required]
    public ContractType ContractType { get; set; }
    
    [Required]
    public DateOnly StartDate { get; set; }
    
    [Required]
    public DateOnly EndDate { get; set; }
    
    public string? Status { get; set; } = string.Empty;
    

    public string? ServiceConditions { get; set; } = string.Empty;
    
    [Required]
    public int CompanyId { get; set; }
    
    [Required]
    public int SeasonId { get; set; }

    public List<VehicleContractUpdateModel>? VehicleContracts { get; set; }
}