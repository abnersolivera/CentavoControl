using CentavoControl.Application.Commands.Account;
using CentavoControl.Application.Queries.Account;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Queries;

public class AccountQueryTests : IClassFixture<TestDatabaseFixture>
{
    private readonly  IAccountCommand _accountCommand;
    private readonly IAccountQuery _accountQuery;

    public AccountQueryTests(TestDatabaseFixture fixture)
    {
        IAccountRepository accountRepository = new AccountRepository(fixture.DbContext);
        _accountCommand = new AccountCommandHandler(accountRepository);
        _accountQuery = new AccountQueryHandler(accountRepository);
    }
    
    [Fact]
    public async Task Should_Get_Account_By_Id()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account",1000.00m,true);
        var accountNew = await _accountCommand.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new GetAccountByIdQuery();
        command.SetId(accountNew.Id.ToString());
        
        // Act
        var account = await _accountQuery.GetAccountByIdAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(account);
        Assert.Equal(accountNew.Id, account.Id);
    }
    
    [Fact]
    public async Task Should_Get_Accounts_By_UserId()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account",1000.00m,true);
        var accountNew = await _accountCommand.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new GetAccountsByUserIdQuery();
        command.SetUserId(accountNew.UserId);
        
        // Act
        var accounts = await _accountQuery.GetAccountsByUserIdAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(accounts);
        Assert.Contains(accounts, x => x.Id == accountNew.Id);
    }
}