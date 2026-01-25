using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class OrderSearchModel
{
    public int? Id { get; set; }
    public int[]? Ids { get; set; }
    public int? UserId { get; set; }
    public int? PilgrimCompanyId { get; set; }
    public int? CompanyId { get; set; }
    public string? InvoiceNo { get; set; }
    public OrderStatus? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
