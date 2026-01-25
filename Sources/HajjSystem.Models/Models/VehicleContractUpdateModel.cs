using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class VehicleContractUpdateModel
{

    public int? Id { get; set; }
    
    [Required]
    public int VehicleId { get; set; }
    
    [Required]
    public int ContractId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int AgreedSeat { get; set; }
    
    [Required]
    public int CompanyId { get; set; }
}
