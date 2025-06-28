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

        await _repository.AddAsync(account, CancellationToken.None);

        var loadedAccount = await _repository.GetByIdAsync(account.Id, CancellationToken.None);

        Assert.NotNull(loadedAccount);
        Assert.Equal(account.Id, loadedAccount.Id);
        Assert.Equal(account.Name, loadedAccount.Name);
        Assert.Equal(account.InitialBalance, loadedAccount.InitialBalance);
        Assert.Equal(account.IsMainAccount, loadedAccount.IsMainAccount);
        Assert.Equal(account.UserId, loadedAccount.UserId);
    }

    [Fact]
    public async Task Should_Update_Account_Correctly()
    {
        var account = new Account(
            Guid.NewGuid(),
            "Test Account",
            1000.00m,
            true,
            Guid.NewGuid().ToString()
        );

        await _repository.AddAsync(account, CancellationToken.None);

        account.ChangeName("Updated Account");

        await _repository.UpdateAsync(account, CancellationToken.None);

        var updatedAccount = await _repository.GetByIdAsync(account.Id, CancellationToken.None);

        Assert.NotNull(updatedAccount);
        Assert.Equal("Updated Account", updatedAccount.Name);
    }

    [Fact]
    public async Task Should_Delete_Account_Correctly()
    {
        var account = new Account(
            Guid.NewGuid(),
            "Test Account",
            1000.00m,
            true,
            Guid.NewGuid().ToString()
        );

        await _repository.AddAsync(account, CancellationToken.None);

        await _repository.DeleteAsync(account, CancellationToken.None);

        var deletedAccount = await _repository.GetByIdAsync(account.Id, CancellationToken.None);

        Assert.Null(deletedAccount);
    }

    [Fact]
    public async Task Should_Retrieve_Account_Correctly()
    {
        var account = new Account(
            Guid.NewGuid(),
            "Test Account",
            1000.00m,
            true,
            Guid.NewGuid().ToString()
        );

        await _repository.AddAsync(account, CancellationToken.None);

        var retrievedAccount = await _repository.GetByIdAsync(account.Id, CancellationToken.None);

        Assert.NotNull(retrievedAccount);
        Assert.Equal(account.Id, retrievedAccount.Id);
        Assert.Equal(account.Name, retrievedAccount.Name);
        Assert.Equal(account.InitialBalance, retrievedAccount.InitialBalance);
        Assert.Equal(account.IsMainAccount, retrievedAccount.IsMainAccount);
        Assert.Equal(account.UserId, retrievedAccount.UserId);
    }

    [Fact]
    public async Task Should_Retrive_Account_UserId_Correctly()
    {
        var userId = Guid.NewGuid().ToString();
        List<Account> accounts =
        [
            new(
                Guid.NewGuid(),
                "Test Account",
                1001.00m,
                true,
                userId
            ),
            new(
                Guid.NewGuid(),
                "Test Account",
                1010.00m,
                true,
                userId
            ),
            new(
                Guid.NewGuid(),
                "Test Account",
                1000.00m,
                true,
                userId
            ),
            new(
                Guid.NewGuid(),
                "Test Account",
                1000.00m,
                true,
                Guid.NewGuid().ToString()
            )
        ];

        foreach (var account in accounts)
            await _repository.AddAsync(account, CancellationToken.None);

        var retrievedAccount = await _repository.GetByUserIdAsync(userId, CancellationToken.None);
        
        Assert.NotNull(retrievedAccount);
        Assert.Equal(3, retrievedAccount.Count());
    }
}