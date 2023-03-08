using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DieticianMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IBodyMeasurementsRepository, BodyMeasurementsRepository>();
            return services;
        }
    }
}
