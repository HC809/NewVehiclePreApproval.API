using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewVehiclePreApproval.Domain.Users;
using NewVehiclePreApproval.Domain.Dealerships;

namespace NewVehiclePreApproval.Infrastructure.Configurations;
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name).IsRequired().HasMaxLength(255);
        builder.Property(user => user.Email).IsRequired().HasMaxLength(255);
        builder.Property(user => user.HashPassword).IsRequired();
        builder.Property(user => user.IsActive).IsRequired();
        builder.Property(user => user.DealershipId).IsRequired();

        builder.Property(user => user.Role)
           .HasConversion(type => type.ToString(), value => (UserRole)Enum.Parse(typeof(UserRole), value));

        builder.Property(user => user.VerificationType)
            .HasConversion(type => type.ToString(), value => (VerificationType)Enum.Parse(typeof(VerificationType), value));

        builder.HasOne<Dealership>()
            .WithMany()
            .HasForeignKey(x => x.DealershipId)
            .OnDelete(DeleteBehavior.NoAction);

        // Índices
        builder.HasIndex(user => user.Email).IsUnique();
    }
}
