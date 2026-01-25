using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models
{
    public class PackageTypeCreateModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Detail { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}