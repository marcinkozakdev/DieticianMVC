using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DieticianMVC.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDieticianService, DieticianService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
