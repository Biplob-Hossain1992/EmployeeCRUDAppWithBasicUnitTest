using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeCRUDApp.Application.Interfaces.IRepository;
using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.Services;
using EmployeeCRUDApp.Infrastructure.Repositories;

namespace EmployeeCRUDApp.Infrastructure.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPerformanceReviewService, PerformanceReviewService>();
            services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();
            return services;
        }
    }
}
