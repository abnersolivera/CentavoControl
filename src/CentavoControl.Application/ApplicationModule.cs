namespace CentavoControl.Application;

public static class ApplicationModule
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services
            .AddValidators()
            .AddApplication();
        
        return services;
    }
    
    private static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAccountCommandHandeler, AccountCommandHandeler>();
        services.AddScoped<IAccountQueryHandler, AccountQueryHandler>();
        services.AddScoped<ICategoryCommandHandler, CategoryCommandHandler>();
        services.AddScoped<ICategoryQueryHandler, CategoryQueryHandler>();
        
        return services;
    }
    
    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
        return services;
    }
}