﻿using FleetManager.Application.Interfaces;
using FleetManager.Infrastructure.Data;
using FleetManager.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)

        {
            services.AddDbContext<FleetDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FleetManager") ??
                throw new InvalidOperationException("Connection string 'FleetManagerWebAppContext' not found.")));

            services.AddScoped<IFleetManagerRepository, FleetManagerRepository>();
            return services;

        }
    }
}

