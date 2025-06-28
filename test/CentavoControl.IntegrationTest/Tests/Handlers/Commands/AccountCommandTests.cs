namespace CentavoControl.IntegrationTest.Tests.Handlers.Commands;

public class AccountCommandTests : IClassFixture<TestDatabaseFixture>
{
    private readonly  IAccountApplication _accountApplication;

    public AccountCommandTests(TestDatabaseFixture fixture)
    {
        IAccountRepository accountRepository = new AccountRepository(fixture.DbContext);
        _accountApplication = new AccountCommandHandler(accountRepository);
    }
    
    [Fact]
    public async Task Should_Get_Account_By_Id()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account",1000.00m,true);
        var accountNew = await _accountApplication.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new GetAccountByIdCommand();
        command.SetId(accountNew.Id.ToString());
        
        // Act
        var account = await _accountApplication.GetAccountByIdAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(account);
        Assert.Equal(accountNew.Id, account.Id);
    }
    
    [Fact]
    public async Task Should_Get_Accounts_By_UserId()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account",1000.00m,true);
        var accountNew = await _accountApplication.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new GetAccountsByUserIdCommand();
        command.SetUserId(accountNew.UserId);
        
        // Act
        var accounts = await _accountApplication.GetAccountsByUserIdAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(accounts);
        Assert.Contains(accounts, x => x.Id == accountNew.Id);
    }
    
    [Fact]
    public async Task Should_Add_Account()
    {
        // Arrange
        var command = new AddAccountCommand("New Account", 500.00m, false);
        
        // Act
        var account = await _accountApplication.AddAccountAsync(command, CancellationToken.None);
        
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
        var accountNew = await _accountApplication.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new UpdateAccountCommand("Updated Account");
        command.SetAccountId(accountNew.Id.ToString());
        
        // Act
        var updatedAccount = await _accountApplication.UpdateAccountAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(updatedAccount);
        Assert.Equal("Updated Account", updatedAccount.Name);
    }
    
    [Fact]
    public async Task Should_Delete_Account()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account",1000.00m,true);
        var accountNew = await _accountApplication.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var command = new DeleteAccountCommand();
        command.SetAccountId(accountNew.Id.ToString());
        
        // Act
        await _accountApplication.DeleteAccountAsync(command, CancellationToken.None);
        
        var getAccountCommand = new GetAccountByIdCommand();
        getAccountCommand.SetId(accountNew.Id.ToString());
        
        var deletedAccount = await _accountApplication.GetAccountByIdAsync(getAccountCommand, CancellationToken.None);
        
        // Assert
        Assert.Null(deletedAccount);
    }
}