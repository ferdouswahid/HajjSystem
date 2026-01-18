using System.ComponentModel.DataAnnotations;

namespace HajjSystem.Models.Models;

public class SeasonModel
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    public bool IsCurrent { get; set; }
    
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public bool IsEnabled { get; set; }

}
