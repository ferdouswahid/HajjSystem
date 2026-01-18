using System.ComponentModel.DataAnnotations.Schema;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities;

public class Contract : BaseEntity
{
    public int VendorId { get; set; }
    [ForeignKey("VendorId")]
    public Vendor? Vendor { get; set; }
    
    public ContractType ContractType { get; set; }
    
    public DateOnly StartDate { get; set; }
    
    public DateOnly EndDate { get; set; }
    
    public string Status { get; set; } = string.Empty;
    
    public string ServiceConditions { get; set; } = string.Empty; // Text: Cleanliness, maintenance
    
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
    
    public int SeasonId { get; set; }
    [ForeignKey("SeasonId")]
    public Season? Season { get; set; }
}
