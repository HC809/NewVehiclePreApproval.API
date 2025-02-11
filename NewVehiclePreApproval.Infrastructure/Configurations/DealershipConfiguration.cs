using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewVehiclePreApproval.Domain.Dealerships;

namespace NewVehiclePreApproval.Infrastructure.Configurations;

internal sealed class DealershipConfiguration : IEntityTypeConfiguration<Dealership>
{
    public void Configure(EntityTypeBuilder<Dealership> builder)
    {
        builder.ToTable("dealerships");
        builder.HasKey(dealership => dealership.Id);

        builder.Property(dealership => dealership.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(dealership => dealership.Address)
            .HasMaxLength(500); 

        builder.Property(dealership => dealership.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(dealership => dealership.Email)
            .HasMaxLength(255);

        //builder.Property(dealership => dealership.AdminUserId)
        //    .IsRequired();

        // Índices
        builder.HasIndex(dealership => dealership.Email).IsUnique();
        builder.HasIndex(dealership => dealership.Name).IsUnique();
        builder.HasIndex(dealership => dealership.PhoneNumber).IsUnique();
    }
}