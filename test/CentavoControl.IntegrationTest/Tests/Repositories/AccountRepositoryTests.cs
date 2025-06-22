using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Interfaces.Repositories;
using CentavoControl.Infrastructure.Data;
using CentavoControl.Infrastructure.Repositories;
using CentavoControl.IntegrationTest.Common;

namespace CentavoControl.IntegrationTest.Tests.Repositories;

public class AccountRepositoryTests(TestDatabaseFixture fixture) : IClassFixture<TestDatabaseFixture>
{
    private readonly IAccountRepository _repository = new AccountRepository(fixture.DbContext);

    [Fact]
    public async Task Should_Persist_Account_Correctly()
    {
        var account = new Account(
            Guid.NewGuid(),
            "Test Account",
            1000.00m,
            true,
            Guid.NewGuid().ToString()
        );

        await _repository.AddAsync(account);
        
        var loadedAccount = await _repository.GetByIdAsync(account.Id);
        
        Assert.NotNull(loadedAccount);
        Assert.Equal(account.Id, loadedAccount.Id);
        Assert.Equal(account.Name, loadedAccount.Name);
        Assert.Equal(account.InitialBalance, loadedAccount.InitialBalance);
        Assert.Equal(account.IsMainAccount, loadedAccount.IsMainAccount);
        Assert.Equal(account.UserId, loadedAccount.UserId);
    }
}