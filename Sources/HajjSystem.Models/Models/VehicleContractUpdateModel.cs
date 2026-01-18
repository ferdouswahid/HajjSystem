using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class VehicleContractUpdateModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int VehicleId { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int AgreedSeat { get; set; }
    
    [Required]
    public string ServiceConditions { get; set; }
    
    [Required]
    public string Status { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
}
