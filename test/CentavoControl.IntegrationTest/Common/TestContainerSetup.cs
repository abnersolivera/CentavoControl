using DotNet.Testcontainers.Builders;
using Testcontainers.PostgreSql;

namespace CentavoControl.IntegrationTest.Common;

public static class TestContainerSetup
{
    public static async Task<PostgreSqlContainer> StartPostgresContainerAsync()
    {
        var containerBuilder = new PostgreSqlBuilder()
            .WithDatabase("centavo_test")
            .WithUsername("postgres")
            .WithPassword("Your_password123")
            .WithImage("postgres:latest")
            .WithPortBinding(5432, true)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5432))
            .WithCleanUp(true)
            .WithName("CentavoControl.PostgresTestContainer");
        
        var container = containerBuilder.Build();
        
        await container.StartAsync();

        return container;
    }
}