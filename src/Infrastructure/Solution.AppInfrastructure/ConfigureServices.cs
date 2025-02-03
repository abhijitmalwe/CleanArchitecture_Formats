using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PdsCleanAppCore.Common.Interfaces;
using PdsCleanAppInfrastructure.DbPersistence;
using PdsCleanAppInfrastructure.Interceptors;
using PdsCleanAppInfrastructure.Services;

namespace PdsCleanAppInfrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddSingleton<IDapperSqlConnectionService>(new DapperSqlConnectionService(configuration.GetConnectionString("DefaultConnection")!));
            
            return services;
        }
    }
}
