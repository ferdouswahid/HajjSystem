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
    
    public DbSet<MealType> MealTypes { get; set; }
    public DbSet<Contract> Contracts { get; set; }

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
    }
}
