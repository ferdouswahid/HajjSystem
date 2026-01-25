namespace HajjSystem.Models.Models;

public class VehicleContractModel
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public VehicleModel? Vehicle { get; set; }
    public int ContractId { get; set; }
    public ContractModel? Contract { get; set; }
    public int AgreedSeat { get; set; }
    public int CompanyId { get; set; }
    public CompanyModel? Company { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEnabled { get; set; }
}
