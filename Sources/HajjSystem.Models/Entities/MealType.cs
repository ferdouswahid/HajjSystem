using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace HajjSystem.Models.Entities;

// Composite unique index for Name and CompanyId
[Index(nameof(Name), nameof(CompanyId), IsUnique = true)]
public class MealType : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string? Detail { get; set; }

    [Required]
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
}
