namespace CentavoControl.Configurations;


/// <summary>
/// The Swagger configuration.
/// </summary>
public static class SwaggerConfiguration
{
    /// <summary>
    /// Configures the Swagger services.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
        return app;
    }
}