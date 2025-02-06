using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewVehiclePreApproval.Domain.Requests;

namespace NewVehiclePreApproval.Infrastructure.Configurations;
internal sealed class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("requests");
        builder.HasKey(request => request.Id);

        // SellerInformation: Propiedades del vendedor
        builder.OwnsOne(request => request.SellerInformation, seller =>
        {
            seller.Property(s => s.Dealership)
                .IsRequired()
                .HasMaxLength(250);

            seller.Property(s => s.VendorName)
                .IsRequired()
                .HasMaxLength(200);
        });

        // ClientInformation: Propiedades del cliente
        builder.OwnsOne(request => request.ClientInformation, client =>
        {
            client.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(250);

            client.Property(c => c.Email)
                .HasMaxLength(150);

            client.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(8);

            client.Property(c => c.Dni)
                .IsRequired()
                .HasMaxLength(13);

            client.Property(c => c.Rtn)
                .HasMaxLength(14);

            client.Property(c => c.EstimatedMonthlyIncome)
                .HasPrecision(18, 2); 

            client.Property(c => c.State).IsRequired();
            client.Property(c => c.City).IsRequired();
            client.Property(c => c.HomeAddress).IsRequired();
            client.Property(c => c.WorkOrBusinessName).IsRequired();
            client.Property(c => c.WorkOrBusinessDescription);
            client.Property(c => c.WorkOrBusinessAddress).IsRequired();
        });

        // VehicleInformation: Propiedades del vehículo
        builder.OwnsOne(request => request.VehicleInformation, vehicle =>
        {
            vehicle.Property(v => v.Brand)
                .IsRequired()
                .HasMaxLength(50);

            vehicle.Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(50);

            vehicle.Property(v => v.Year)
                .IsRequired();
            
            vehicle.Property(v => v.Type)
                .IsRequired();

            vehicle.Property(v => v.Price)
                .IsRequired()
                .HasPrecision(18, 2); 
        });

        // Estado de la solicitud
        builder.Property(request => request.Status)
            .IsRequired()
            .HasConversion(
                status => status.ToString(), // Conversión de Enum a string
                value => (RequestStatus)Enum.Parse(typeof(RequestStatus), value)
            );

        builder.Property(request => request.RejectionReason)
            .HasMaxLength(500);

        // Índices
        builder.HasIndex(request => request.Id).IsUnique();
    }
}
