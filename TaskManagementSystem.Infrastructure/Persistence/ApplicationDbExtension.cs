
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagementSystem.Infrastructure.Persistence
{
    public static class ApplicationDbExtension
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            DbSettings dbSettings = new DbSettings()
            {
                ConnectionString = configuration.GetSection(DbSettings.ConnectionStringSection).Value
            };
                              
            services.AddSingleton(dbSettings);

            var name = typeof(ApplicationDbContext).Assembly.FullName;

            services.AddDbContextPool<ApplicationDbContext, ApplicationDbContext>(
                opt => opt.UseNpgsql(dbSettings.ConnectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly(name)));
        }

        public static void RunDbContextMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
