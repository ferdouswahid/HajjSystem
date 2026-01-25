using System;

namespace HajjSystem.Models.Models
{
    public class MealServiceLevelModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Detail { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}
