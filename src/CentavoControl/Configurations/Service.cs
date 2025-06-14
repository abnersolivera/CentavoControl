namespace CentavoControl.Configurations;

/// <summary>
/// The service configuration.
/// </summary>
public static class Service
{
    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging();
        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger("IoC")!;
        
        services
            .ConfigureInfrastructure(configuration)
            .Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
        return services;
    }
}