using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HajjSystem.Models.Entities
{
    public class PackageType : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Detail { get; set; }

        // Foreign key to Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        
        public ICollection<Package>? Packages { get; set; }
    }
}