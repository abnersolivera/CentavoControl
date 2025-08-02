using CentavoControl.Application.Commands.Account;
using CentavoControl.Application.Queries.Account;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Commands;

public class AccountCommandTests : IClassFixture<TestDatabaseFixture>
{
    private readonly  IAccountCommandHandeler _accountCommandHandeler;
    private readonly IAccountQueryHandler _accountQueryHandler;

    public AccountCommandTests(TestDatabaseFixture fixture)
    {
        IAccountRepository accountRepository = new AccountRepository(fixture.DbContext);
        _accountCommandHandeler = new AccountCommandHandler(accountRepository);
        _accountQueryHandler = new AccountQueryHandler(accountRepository);
    }
    
    [Fact]
    public async Task Should_Add_Account()
    {
        // Arrange
        var command = new AddAccountCommand("New Account", 500.00m, false);
        
        // Act
        var account = await _accountCommandHandeler.AddAccountAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(account);
        Assert.Equal("New Account", account.Name);
        Assert.Equal(500.00m, account.InitialBalance);
        Assert.False(account.IsMainAccount);
    }
    
    [Fact]
    public async Task Should_Update_Account()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account",1000.00m,true);
        var accountNew = await _accountCommandHandeler.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new UpdateAccountCommand("Updated Account");
        command.SetAccountId(accountNew.Id.ToString());
        
        // Act
        var updatedAccount = await _accountCommandHandeler.UpdateAccountAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(updatedAccount);
        Assert.Equal("Updated Account", updatedAccount.Name);
    }
    
    [Fact]
    public async Task Should_Delete_Account()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account",1000.00m,true);
        var accountNew = await _accountCommandHandeler.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new DeleteAccountCommand();
        command.SetAccountId(accountNew.Id.ToString());
        
        // Act
        await _accountCommandHandeler.DeleteAccountAsync(command, CancellationToken.None);
        
        var getAccountCommand = new GetAccountByIdQuery();
        getAccountCommand.SetId(accountNew.Id.ToString());
        
        var deletedAccount = await _accountQueryHandler.GetAccountByIdAsync(getAccountCommand, CancellationToken.None);
        
        // Assert
        Assert.Null(deletedAccount);
    }
}