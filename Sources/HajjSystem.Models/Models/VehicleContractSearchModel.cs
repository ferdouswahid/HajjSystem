namespace HajjSystem.Models.Models;

public class VehicleContractSearchModel
{
    public int? Id { get; set; }
    public int[]? Ids { get; set; }
    public int? VehicleId { get; set; }
    public int? ContractId { get; set; }
    public int? CompanyId { get; set; }
    public int? MinAgreedSeat { get; set; }
    public int? MaxAgreedSeat { get; set; }
}
