using CentavoControl.Application.Commands.Account;
using CentavoControl.Application.Commands.Category;
using CentavoControl.Application.Commands.Payable;
using CentavoControl.Application.Queries.Payable;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Commands;

public class PayableCommandHandlerTests : IClassFixture<TestDatabaseFixture>
{
    private readonly IPayableCommandHandler _payableCommandHandler;
    private readonly IPayableQueryHandler _payableQueryHandler;
    private readonly IAccountCommandHandeler _accountCommandHandler;
    private readonly ICategoryCommandHandler _categoryCommandHandler;

    public PayableCommandHandlerTests(TestDatabaseFixture fixture)
    {
        IPayableRepository payableRepository = new PayableRepository(fixture.DbContext);
        _payableCommandHandler = new PayableCommandHandler(payableRepository);
        _payableQueryHandler = new PayableQueryHandler(payableRepository);
        IAccountRepository accountRepository = new AccountRepository(fixture.DbContext);
        _accountCommandHandler = new AccountCommandHandler(accountRepository);
        ICategoryRepository categoryRepository = new CategoryRepository(fixture.DbContext);
        _categoryCommandHandler = new CategoryCommandHandler(categoryRepository);
    }

    [Fact]
    public async Task Should_Add_Payable()
    {
        // Arrange

        var accountCommand = new AddAccountCommand("Test Account", 1000.00m, true);
        var account = await _accountCommandHandler.AddAccountAsync(accountCommand, CancellationToken.None);
        
        var categoryCommand = new AddCategoryCommand("Test Category", "Expense");
        var category = await _categoryCommandHandler.AddCategoryAsync(categoryCommand, CancellationToken.None);
        
        var command = new AddPayableCommand("New Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id);
        
        // Act
        var payable = await _payableCommandHandler.AddPayableAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(payable);
        Assert.Equal("New Payable", payable.Description);
        Assert.Equal(100.00m, payable.Amount);
        Assert.Equal(DateTime.UtcNow.AddDays(30).Date, payable.DueDate.Date);
    }

    [Fact]
    public async Task Should_Update_Payable()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account", 1000.00m, true);
        var account = await _accountCommandHandler.AddAccountAsync(accountCommand, CancellationToken.None);
        var categoryCommand = new AddCategoryCommand("Test Category", "Expense");
        var category = await _categoryCommandHandler.AddCategoryAsync(categoryCommand, CancellationToken.None);
        var addCommand =
            new AddPayableCommand("New Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id);
        var payable = await _payableCommandHandler.AddPayableAsync(addCommand, CancellationToken.None);

        var command = new UpdatePayableCommand("Updated Payable", 150.00m, DateTime.UtcNow.AddDays(15), account.Id,
            category.Id);
        command.SetPayableId(payable.Id.ToString());

        // Act
        var updatedPayable = await _payableCommandHandler.UpdatePayableAsync(command, CancellationToken.None);

        // Assert
        Assert.NotNull(updatedPayable);
        Assert.Equal("Updated Payable", updatedPayable.Description);
        Assert.Equal(150.00m, updatedPayable.Amount);
        Assert.Equal(DateTime.UtcNow.AddDays(15).Date, updatedPayable.DueDate.Date);
    }

    [Fact]
    public async Task Should_Delete_Payable()
    {
        // Arrange
        var accountCommand = new AddAccountCommand("Test Account", 1000.00m, true);
        var account = await _accountCommandHandler.AddAccountAsync(accountCommand, CancellationToken.None);
        var categoryCommand = new AddCategoryCommand("Test Category", "Expense");
        var category = await _categoryCommandHandler.AddCategoryAsync(categoryCommand, CancellationToken.None);
        var addCommand =
            new AddPayableCommand("New Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id);
        var payable = await _payableCommandHandler.AddPayableAsync(addCommand, CancellationToken.None);

        var command = new DeletePayableCommand(payable.Id);

        // Act
        await _payableCommandHandler.DeletePayableAsync(command, CancellationToken.None);

        var query = new GetPayableQuery(payable.Id);
        var deletedPayable = await _payableQueryHandler.GetPayableAsync(query, CancellationToken.None);
        // Assert
        Assert.Null(deletedPayable);
    }

}