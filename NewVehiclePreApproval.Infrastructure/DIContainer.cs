using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewVehiclePreApproval.Application.Abstractions.Data;
using NewVehiclePreApproval.Domain.Abstractions;
using NewVehiclePreApproval.Domain.Requests;
using NewVehiclePreApproval.Infrastructure.Data;
using NewVehiclePreApproval.Infrastructure.Exceptions;
using NewVehiclePreApproval.Infrastructure.Repositories;

namespace NewVehiclePreApproval.Infrastructure;
public static class DIContainer
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CofisaDb") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IRequestRepository, RequestRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        services.AddSingleton<ISqlServerExceptionMapper, SqlServerExceptionMapper>();
    }
}
