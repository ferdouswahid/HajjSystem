namespace HajjSystem.Models.Models;

public class MealTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Detail { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEnabled { get; set; }
}
