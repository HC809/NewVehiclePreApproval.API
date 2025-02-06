﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NewVehiclePreApproval.Application.Abstractions.Behaviors;

namespace NewVehiclePreApproval.Application;
public static class DIContainer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DIContainer).Assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DIContainer).Assembly, includeInternalTypes: true);

        return services;
    }
}
