using Hangfire;
using Hangfire.SqlServer;
using OurAppWithHangfire.Interface;
using OurAppWithHangfire.Repository;
using OurAppWithHangfire.Services;

namespace OurAppWithHangfire.IoC
{
    public static class ContainerInjector
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            //Fetching Connection string from APPSETTINGS.JSON  
            var ConnectionString = configuration.GetConnectionString("DbConnectionString");

            // Services
            services.AddScoped<IBackGroundJobService, CustomJobService>();

            // Repositories
            services.AddScoped<ICustomJob, CustomJobRepository>();

            var sqlStorage = new SqlServerStorage(ConnectionString);

            var options = new BackgroundJobServerOptions
            {
                ServerName = "Test Server"
            };

            JobStorage.Current = sqlStorage;

            services.AddHangfire(configuration => configuration
                 .SetDataCompatibilityLevel(CompatibilityLevel.Version_170).UseSimpleAssemblyNameTypeSerializer()
                 .UseRecommendedSerializerSettings().UseSqlServerStorage(ConnectionString, new SqlServerStorageOptions
                 {
                     CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                     SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                     QueuePollInterval = TimeSpan.Zero,
                     UseRecommendedIsolationLevel = true,
                     DisableGlobalLocks = true
                 }));

            services.AddHangfireServer();
        }
    }
}