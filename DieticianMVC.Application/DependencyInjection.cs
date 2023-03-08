using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.Services;
using DieticianMVC.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DieticianMVC.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPatientService, PatientService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
