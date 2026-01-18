using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Models.Entities;

[Index(nameof(Name), IsUnique = true)]
public class MealType : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string? Detail { get; set; }
}
