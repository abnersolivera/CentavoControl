using CentavoControl.Infrastructure.Data;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace CentavoControl.IntegrationTest.Common;

public class TestDatabaseFixture : IAsyncLifetime
{
    public PostgreSqlContainer Container { get; private set; }
    public DataContext DbContext { get; private set; }

    public TestDatabaseFixture()
    {
    }

    public async Task InitializeAsync()
    {
        Container = await TestContainerSetup.StartPostgresContainerAsync();
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseNpgsql(Container.GetConnectionString())
            .Options;
        DbContext = new DataContext(options);
        await DbContext.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await DbContext.Database.EnsureDeletedAsync();
        await Container.StopAsync();
    }
}