using System.ComponentModel.DataAnnotations;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Entities;

public class Location : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}
