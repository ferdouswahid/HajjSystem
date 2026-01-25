using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models
{
    public class MealServiceLevelCreateModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Detail { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
    }
}
