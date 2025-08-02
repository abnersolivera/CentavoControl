using CentavoControl.Application.Commands.Account;
using CentavoControl.Application.Commands.Category;
using CentavoControl.Application.Commands.Payable;
using CentavoControl.Application.Queries.Payable;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Queries;

public class PayableQueryTests : IClassFixture<TestDatabaseFixture>
{
    private readonly ICategoryCommandHandler _categoryCommandHandler;
    private readonly IAccountCommandHandeler _accountCommandHandler;
    private readonly IPayableQueryHandler _payableQueryHandler;
    private readonly IPayableCommandHandler _payableCommandHandler;
    
    public PayableQueryTests(TestDatabaseFixture fixture)
    {
        ICategoryRepository categoryRepository = new CategoryRepository(fixture.DbContext);
        _categoryCommandHandler = new CategoryCommandHandler(categoryRepository);
        IAccountRepository accountRepository = new AccountRepository(fixture.DbContext);
        _accountCommandHandler = new AccountCommandHandler(accountRepository);
        IPayableRepository payableRepository = new PayableRepository(fixture.DbContext);
        _payableQueryHandler = new PayableQueryHandler(payableRepository);
        _payableCommandHandler = new PayableCommandHandler(payableRepository);
    }

    [Fact]
    public async Task Should_Get_Payable_By_UserId()
    {
        // Arrange
        var userId = "0741789C-C8B4-468F-BE98-CC7569D85918";
        var categoryCommand = new AddCategoryCommand("Test Category", "Expense");
        var category = await _categoryCommandHandler.AddCategoryAsync(categoryCommand, CancellationToken.None);
        
        var accountCommand = new AddAccountCommand("Test Account", 1000, false);
        var account = await _accountCommandHandler.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var payableCommand = new AddPayableCommand("Test Payable", 200, DateTime.UtcNow, account.Id, category.Id);
        await _payableCommandHandler.AddPayableAsync(payableCommand, CancellationToken.None);
        
        var query = new GetPayableByUserIdQuery(userId);
        
        // Act
        var payables = await _payableQueryHandler.GetAllPayablesAsync(query, CancellationToken.None);
        
        // Assert
        Assert.NotNull(payables);
        Assert.NotEmpty(payables);
    }

    [Fact]
    public async Task Should_Get_Payable_By_Id()
    {
        // Arrange
        var categoryCommand = new AddCategoryCommand("Test Category", "Expense");
        var category = await _categoryCommandHandler.AddCategoryAsync(categoryCommand, CancellationToken.None);
        
        var accountCommand = new AddAccountCommand("Test Account", 1000, false);
        var account = await _accountCommandHandler.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var payableCommand = new AddPayableCommand("Test Payable", 200, DateTime.UtcNow, account.Id, category.Id);
        var addedPayable = await _payableCommandHandler.AddPayableAsync(payableCommand, CancellationToken.None);
        
        var query = new GetPayableByIdQuery(addedPayable.Id);
        
        // Act
        var payable = await _payableQueryHandler.GetPayableByIdAsync(query, CancellationToken.None);
        
        // Assert
        Assert.NotNull(payable);
        Assert.Equal(addedPayable.Id, payable.Id);
        Assert.Equal("Test Payable", payable.Description);
    }

    [Fact]
    public async Task Should_Get_Payables_By_AccountId()
    {
        // Arrange
        var categoryCommand = new AddCategoryCommand("Test Category", "Expense");
        var category = await _categoryCommandHandler.AddCategoryAsync(categoryCommand, CancellationToken.None);
        
        var accountCommand = new AddAccountCommand("Test Account", 1000, false);
        var account = await _accountCommandHandler.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var payableCommand = new AddPayableCommand("Test Payable", 200, DateTime.UtcNow, account.Id, category.Id);
        await _payableCommandHandler.AddPayableAsync(payableCommand, CancellationToken.None);
        
        var query = new GetPayableByAccountIdQuery(account.Id);
        
        // Act
        var payables = await _payableQueryHandler.GetPayablesByAccountIdAsync(query, CancellationToken.None);
        
        // Assert
        Assert.NotNull(payables);
        Assert.NotEmpty(payables);
    }

    [Fact]
    public async Task Should_Get_Payables_By_CategoryId()
    {
        // Arrange
        var categoryCommand = new AddCategoryCommand("Test Category", "Expense");
        var category = await _categoryCommandHandler.AddCategoryAsync(categoryCommand, CancellationToken.None);
        
        var accountCommand = new AddAccountCommand("Test Account", 1000, false);
        var account = await _accountCommandHandler.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var payableCommand = new AddPayableCommand("Test Payable", 200, DateTime.UtcNow, account.Id, category.Id);
        await _payableCommandHandler.AddPayableAsync(payableCommand, CancellationToken.None);
        
        var query = new GetPayableByCategoryIdQuery(category.Id);
        
        // Act
        var payables = await _payableQueryHandler.GetPayablesByCategoryIdAsync(query, CancellationToken.None);
        
        // Assert
        Assert.NotNull(payables);
        Assert.NotEmpty(payables);
    }
}