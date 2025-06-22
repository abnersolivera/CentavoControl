namespace CentavoControl.Application;

public static class ApplicationModule
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services
            .AddApplication();
        
        return services;
    }
    
    private static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAccountApplication, AccountApplication>();
        
        return services;
    }
}