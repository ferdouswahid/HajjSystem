using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HajjSystem.Models.Entities;

[Index(nameof(CrNumber), IsUnique = true)]
public class Company : BaseEntity
{
     [Required]
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyNameAr { get; set; } = string.Empty;
    
    [Required]
    public string CrNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string VatRegNumber { get; set; } = string.Empty;
    public string BuildingNumber { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
    public ICollection<VehicleDetail> VehicleDetails { get; set; }
    public ICollection<VehicleContract> VehicleContracts { get; set; }
    public ICollection<Vendor> Vendors { get; set; }
    public ICollection<Contract> Contracts { get; set; }
    public ICollection<AirlineContract> AirlineContracts { get; set; }
    public ICollection<AirlineContractDetail> AirlineContractDetails { get; set; }
    public ICollection<Package> Packages { get; set; }
    public ICollection<PackageType> PackageTypes { get; set; }
    public ICollection<PackageVehicle> PackageVehicles { get; set; }
    public ICollection<PackageAirline> PackageAirlines { get; set; }
    public ICollection<MealType> MealTypes { get; set; }
    public ICollection<MealServiceLevel> MealServiceLevels { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Order>? PilgrimOrders { get; set; }
}
