namespace HajjSystem.Models.Models;

public class PackageSearchModel
{
    public int? Id { get; set; }
    public int[]? Ids { get; set; }
    public int? PackageTypeId { get; set; }
    public int? CompanyId { get; set; }
    public int? SeasonId { get; set; }
    public string? Title { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
