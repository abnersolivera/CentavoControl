using CentavoControl.Application.Commands.Account;
using CentavoControl.Application.Queries.Account;

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
        services.AddScoped<IAccountCommand, AccountCommandHandler>();
        services.AddScoped<IAccountQuery, AccountQueryHandler>();
        
        return services;
    }
    
    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
        return services;
    }
}