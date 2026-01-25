using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models;

public class UserSearchModel
{
    public int? Id { get; set; }
    public int[]? Ids { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public UserType? UserType { get; set; }
    public int? CompanyId { get; set; }
    public int? SeasonId { get; set; }
    public string? Mobile { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}
