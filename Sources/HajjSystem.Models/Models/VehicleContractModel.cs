namespace HajjSystem.Models.Models;

public class VehicleContractModel
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public VehicleModel? Vehicle { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int AgreedSeat { get; set; }
    public string ServiceConditions { get; set; }
    public string Status { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEnabled { get; set; }
}
