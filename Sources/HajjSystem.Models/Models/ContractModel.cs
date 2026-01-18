using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class ContractModel
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public ContractType ContractType { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ServiceConditions { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int SeasonId { get; set; }

    public VendorModel? Vendor { get; set; }
    public CompanyModel? Company { get; set; }
    public SeasonModel? Season { get; set; }
}