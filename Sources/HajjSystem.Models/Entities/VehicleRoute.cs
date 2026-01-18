using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Models.Entities;

[Index(nameof(Name), IsUnique = true)]
public class VehicleRoute : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string? Details { get; set; }
    
    public ICollection<VehicleDetail> RouteFromDetails { get; set; }
    public ICollection<VehicleDetail> RouteToDetails { get; set; }
}
