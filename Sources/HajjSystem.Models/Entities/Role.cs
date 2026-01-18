using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace HajjSystem.Models.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Role
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
