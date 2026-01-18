namespace HajjSystem.Models.Models;

public class OperationResponse
{
    public object? Data { get; set; }
    public bool Status { get; set; }
    public string? Message { get; set; } = string.Empty;
}
