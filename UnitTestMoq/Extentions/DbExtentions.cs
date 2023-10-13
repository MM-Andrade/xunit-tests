using Microsoft.EntityFrameworkCore;
using UnitTestMoq.Data;
using UnitTestMoq.Services;

namespace UnitTestMoq.Extentions
{
    public static class DbExtentions
    {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(
                    configuration.GetConnectionString("Sqliteconn"));
            });

            AddAppServices(services);
        }

        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.EnsureCreated();
                    context.Database.Migrate();

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or creating the database.");
                }
            }
            return applicationBuilder;
        }

        public static void AddAppServices(IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
        }
    }
}
