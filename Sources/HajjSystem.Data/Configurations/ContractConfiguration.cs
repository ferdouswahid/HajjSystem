using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HajjSystem.Models.Entities;

namespace HajjSystem.Data.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("Contracts");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Status)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.ServiceConditions)
            .IsRequired();

        builder.Property(c => c.StartDate)
            .IsRequired();

        builder.Property(c => c.EndDate)
            .IsRequired();

        builder.Property(c => c.ContractType)
            .IsRequired();

        builder.HasOne(c => c.Vendor)
            .WithMany(v => v.Contracts)
            .HasForeignKey(c => c.VendorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Company)
            .WithMany(co => co.Contracts)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Season)
            .WithMany(s => s.Contracts)
            .HasForeignKey(c => c.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
