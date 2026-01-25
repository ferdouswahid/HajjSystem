using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Models.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public class Season : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
        public ICollection<AirlineContract>? AirlineContracts { get; set; }
        public ICollection<Package>? Packages { get; set; }
        public ICollection<PackageVehicle>? PackageVehicles { get; set; }
        public ICollection<PackageAirline>? PackageAirlines { get; set; }
    }
}
