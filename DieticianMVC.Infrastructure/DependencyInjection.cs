using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DieticianMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDieticianRepository, DieticianRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBodyMeasurementsRepository, BodyMeasurementsRepository>();
            return services;
        }
    }
}
