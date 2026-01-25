using Microsoft.EntityFrameworkCore;
using HajjSystem.Models.Entities;

namespace HajjSystem.Data;

public class HajjSystemContext : DbContext
{
    public HajjSystemContext(DbContextOptions<HajjSystemContext> options)
        : base(options)
    {
    }

    public DbSet<Registration> Registrations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<VehicleRoute> VehicleRoutes { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleDetail> VehicleDetails { get; set; }
    public DbSet<VehicleContract> VehicleContracts { get; set; }
 


    public DbSet<AirlineRoute> AirlineRoutes { get; set; }
    public DbSet<AirlineContract> AirlineContracts { get; set; }
    public DbSet<AirlineContractDetail> AirlineContractDetails { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<PackageType> PackageTypes { get; set; }
    public DbSet<PackageVehicle> PackageVehicles { get; set; }
    public DbSet<PackageAirline> PackageAirlines { get; set; }
    
    public DbSet<MealType> MealTypes { get; set; }
    public DbSet<MealServiceLevel> MealServiceLevels { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OrderLog> OrderLogs { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HajjSystemContext).Assembly);

        // Configure VehicleDetail relationships with VehicleRoute
        modelBuilder.Entity<VehicleDetail>()
            .HasOne(vd => vd.RouteFrom)
            .WithMany(vr => vr.RouteFromDetails)
            .HasForeignKey(vd => vd.RouteFromId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<VehicleDetail>()
            .HasOne(vd => vd.RouteTo)
            .WithMany(vr => vr.RouteToDetails)
            .HasForeignKey(vd => vd.RouteToId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure AirlineContractDetail relationships with AirlineRoute
        modelBuilder.Entity<AirlineContractDetail>()
            .HasOne(acd => acd.RouteFrom)
            .WithMany(ar => ar.RouteFromDetails)
            .HasForeignKey(acd => acd.RouteFromId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AirlineContractDetail>()
            .HasOne(acd => acd.RouteTo)
            .WithMany(ar => ar.RouteToDetails)
            .HasForeignKey(acd => acd.RouteToId)
            .OnDelete(DeleteBehavior.Restrict);

        // Explicitly configure Company-Order and Company-PilgrimOrders relationships
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Company)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.PilgrimCompany)
            .WithMany(c => c.PilgrimOrders)
            .HasForeignKey(o => o.PilgrimCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
