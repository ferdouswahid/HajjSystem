using System.ComponentModel.DataAnnotations.Schema;

namespace HajjSystem.Models.Entities;

public class VehicleContract : BaseEntity
{
    public int VehicleId { get; set; }
    [ForeignKey("VehicleId")]
    public Vehicle? Vehicle { get; set; }

    public int ContractId { get; set; }
    [ForeignKey("ContractId")]
    public Contract? Contract { get; set; }

    public int AgreedSeat { get; set; }

    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }

}
