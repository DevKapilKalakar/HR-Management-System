using HRM.Contracts;
using HRM.Infrastructure;
using HRM.Services;
using Microsoft.EntityFrameworkCore;

namespace HR_Management_System.Helper
{
    public static class ServiceExtension
    {
        private const string AppString = "AppConnection";

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(AppString);
            var commandTimeout = (int)TimeSpan.FromMinutes(20).TotalSeconds;

            services.AddDbContextPool<DatabaseContext>
            (o =>
            {
                o.UseSqlServer(connectionString, sqlOpt =>
                {
                    sqlOpt.CommandTimeout(commandTimeout);
                    sqlOpt.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
                });
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
