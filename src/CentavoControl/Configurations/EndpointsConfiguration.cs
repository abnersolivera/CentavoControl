using System.ComponentModel;
using Microsoft.OpenApi.Models;

namespace CentavoControl.Configurations;

/// <summary>
/// The endpoints configuration.
/// </summary>
public static class EndpointsConfiguration
{
    /// <summary>
    /// Configures the endpoints.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app, IConfiguration configuration)
    {
        app.MapControllers();
        return app;
    }

    /// <summary>
    /// Configures the endpoints for the application, including API versioning and Swagger documentation.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureEndpoints(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CenntavoControl API",
                Version = "v1",
                Description = """
                              CentavoControl é uma aplicação para controle de finanças pessoais, focada em facilitar a organização das suas contas a pagar e o gerenciamento de cartões de crédito.
                              """,
                Contact = new OpenApiContact
                {
                    Name = "Suporte Abner",
                    Email = "abnersanto2014@gmail.com",
                    Url = new Uri("https://github.com/abnersolivera/CentavoControl/tree/develop"),
                }
            });

            c.AddSecurityDefinition("BearerAuth",
                new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Enter your JWT token below:"
                });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "BearerAuth" },
                    },
                    new List<string>()
                }
            });

            #region Servers

            c.AddServer(new OpenApiServer
            {
                Url = "http://localhost:5000", 
                Description = "Produção"
            });

            c.AddServer(new OpenApiServer
            {
                Url = "http://localhost:5000", 
                Description = "Homologação"
            });

            c.AddServer(new OpenApiServer
            {
                Url = "http://localhost:5000", 
                Description = "QA"
            });

            c.AddServer(new OpenApiServer
            {
                Url = "http://localhost:5000", 
                Description = "DEV"
            });

            c.AddServer(new OpenApiServer
            {
                Url = "http://localhost:5000", 
                Description = "Local"
            });

            #endregion

            c.CustomSchemaIds(x =>
                x.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? x.Name);


#if DEBUG
            if (Environment.GetEnvironmentVariable("testingEnviroment") != "true")
                Directory.GetFiles("./Configurations/Comments/", "*.xml", SearchOption.TopDirectoryOnly).ToList()
                    .ForEach(xml => c.IncludeXmlComments(xml));
#endif
        });

        return services;
    }
}