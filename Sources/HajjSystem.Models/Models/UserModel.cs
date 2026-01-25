using System;
using System.Collections.Generic;
using HajjSystem.Models.Enums;

namespace HajjSystem.Models.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; }
        public int? CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
        public UserType UserType { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public DateTime PassportValidity { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; }
        public int? SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}