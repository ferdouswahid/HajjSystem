using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class ContractSearchModel
{
    public int? Id { get; set; }
    public int[]? Ids { get; set; }
    public string? Title { get; set; } 
    public int? VendorId { get; set; }
    public ContractType? ContractType { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Status { get; set; }
    public int CompanyId { get; set; }
    public int? SeasonId { get; set; }
}
