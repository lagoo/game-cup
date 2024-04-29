using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICompetitorsGameService, L3CompetitorsGameService>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("CompetitorsServiceUrl").Value);
            });

            return services;
        }

    }
}
