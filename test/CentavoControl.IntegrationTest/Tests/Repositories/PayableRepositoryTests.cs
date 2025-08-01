using CentavoControl.Domain.Enums;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Repositories;

public class PayableRepositoryTests(TestDatabaseFixture fixture) : IClassFixture<TestDatabaseFixture>
{
    private readonly IPayableRepository _repositoryPayable = new PayableRepository(fixture.DbContext);
    private readonly IAccountRepository _repositoryAccount = new AccountRepository(fixture.DbContext);
    private readonly ICategoryRepository _repositoryCategory = new CategoryRepository(fixture.DbContext);

    [Fact]
    public async Task Should_Persist_Payable_Commun_Correctly()
    {
        var userId = Guid.NewGuid().ToString();
        var account = new Account(Guid.NewGuid(), "Test Account", 0, true, userId);
        await _repositoryAccount.AddAsync(account, CancellationToken.None);
        var category = new Category(Guid.NewGuid(), "Test Category", ETransactionType.Income, userId);
        await _repositoryCategory.AddAsync(category, CancellationToken.None);
        var payable = new Payable(Guid.NewGuid(), "Test Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id, userId);
        
        await _repositoryPayable.AddAsync(payable, CancellationToken.None);
        var persistedPayable = await _repositoryPayable.GetByIdAsync(payable.Id, CancellationToken.None);
        
        Assert.NotNull(persistedPayable);
        Assert.Equal(payable.Id, persistedPayable.Id);
        Assert.Equal(payable.Description, persistedPayable.Description);
        Assert.Equal(payable.Amount, persistedPayable.Amount);
        Assert.Equal(payable.DueDate, persistedPayable.DueDate);
        Assert.False(payable.IsPaid);
        Assert.Equal(payable.AccountId, persistedPayable.AccountId);
        Assert.Equal(payable.CategoryId, persistedPayable.CategoryId);
        Assert.Equal(payable.UserId, persistedPayable.UserId);
    }

    [Fact]
    public async Task Should_Update_Payable_Correctly()
    {
        var userId = Guid.NewGuid().ToString();
        var account = new Account(Guid.NewGuid(), "Test Account", 0, true, userId);
        await _repositoryAccount.AddAsync(account, CancellationToken.None);
        var category = new Category(Guid.NewGuid(), "Test Category", ETransactionType.Income, userId);
        await _repositoryCategory.AddAsync(category, CancellationToken.None);
        var payable = new Payable(Guid.NewGuid(), "Test Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id, userId);
        await _repositoryPayable.AddAsync(payable, CancellationToken.None);
        payable.UpdateDetails("Updated Payable", 150.00m, DateTime.UtcNow.AddDays(60), account.Id, category.Id);
        
        await _repositoryPayable.UpdateAsync(payable, CancellationToken.None);
        var updatedPayable = await _repositoryPayable.GetByIdAsync(payable.Id, CancellationToken.None);
        
        Assert.NotNull(updatedPayable);
        Assert.Equal("Updated Payable", updatedPayable.Description);
        Assert.Equal(150.00m, updatedPayable.Amount);
        Assert.Equal(DateTime.UtcNow.AddDays(60).Date, updatedPayable.DueDate.Date);
        Assert.Equal(account.Id, updatedPayable.AccountId);
        Assert.Equal(category.Id, updatedPayable.CategoryId);
    }

    [Fact]
    public async Task Should_Mark_Payable_As_Paid_Correctly()
    {
        var userId = Guid.NewGuid().ToString();
        var account = new Account(Guid.NewGuid(), "Test Account", 0, true, userId);
        await _repositoryAccount.AddAsync(account, CancellationToken.None);
        var category = new Category(Guid.NewGuid(), "Test Category", ETransactionType.Income, userId);
        await _repositoryCategory.AddAsync(category, CancellationToken.None);
        var payable = new Payable(Guid.NewGuid(), "Test Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id, userId);
        await _repositoryPayable.AddAsync(payable, CancellationToken.None);
        payable.MarkAsPaid();
        
        await _repositoryPayable.UpdateAsync(payable, CancellationToken.None);
        var paidPayable = await _repositoryPayable.GetByIdAsync(payable.Id, CancellationToken.None);
        
        Assert.NotNull(paidPayable);
        Assert.True(paidPayable.IsPaid);
    }

    [Fact]
    public async Task Should_Delete_Payable_Correctly()
    {
        var userId = Guid.NewGuid().ToString();
        var account = new Account(Guid.NewGuid(), "Test Account", 0, true, userId);
        await _repositoryAccount.AddAsync(account, CancellationToken.None);
        var category = new Category(Guid.NewGuid(), "Test Category", ETransactionType.Income, userId);
        await _repositoryCategory.AddAsync(category, CancellationToken.None);
        var payable = new Payable(Guid.NewGuid(), "Test Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id, userId);
        await _repositoryPayable.AddAsync(payable, CancellationToken.None);
        
        await _repositoryPayable.DeleteAsync(payable.Id, CancellationToken.None);
        var deletedPayable = await _repositoryPayable.GetByIdAsync(payable.Id, CancellationToken.None);
        
        Assert.Null(deletedPayable);
    }

    [Fact]
    public async Task Should_Get_By_Id_Payable_Correctly()
    {
        var userId = Guid.NewGuid().ToString();
        var account = new Account(Guid.NewGuid(), "Test Account", 0, true, userId);
        await _repositoryAccount.AddAsync(account, CancellationToken.None);
        var category = new Category(Guid.NewGuid(), "Test Category", ETransactionType.Income, userId);
        await _repositoryCategory.AddAsync(category, CancellationToken.None);
        var payable = new Payable(Guid.NewGuid(), "Test Payable", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id, userId);
        
        await _repositoryPayable.AddAsync(payable, CancellationToken.None);
        var fetchedPayable = await _repositoryPayable.GetByIdAsync(payable.Id, CancellationToken.None);
        
        Assert.NotNull(fetchedPayable);
        Assert.Equal(payable.Id, fetchedPayable.Id);
        Assert.Equal(payable.Description, fetchedPayable.Description);
        Assert.Equal(payable.Amount, fetchedPayable.Amount);
        Assert.Equal(payable.DueDate, fetchedPayable.DueDate);
        Assert.Equal(payable.AccountId, fetchedPayable.AccountId);
        Assert.Equal(payable.CategoryId, fetchedPayable.CategoryId);
        Assert.Equal(payable.UserId, fetchedPayable.UserId);
        Assert.False(fetchedPayable.IsPaid);
    }
    
    [Fact]
    public async Task Should_Get_By_UserId_Payables_Correctly()
    {
        var userId = Guid.NewGuid().ToString();
        var account = new Account(Guid.NewGuid(), "Test Account", 0, true, userId);
        await _repositoryAccount.AddAsync(account, CancellationToken.None);
        var category = new Category(Guid.NewGuid(), "Test Category", ETransactionType.Income, userId);
        await _repositoryCategory.AddAsync(category, CancellationToken.None);
        var payable1 = new Payable(Guid.NewGuid(), "Test Payable 1", 100.00m, DateTime.UtcNow.AddDays(30), account.Id, category.Id, userId);
        var payable2 = new Payable(Guid.NewGuid(), "Test Payable 2", 200.00m, DateTime.UtcNow.AddDays(60), account.Id, category.Id, userId);
        
        await _repositoryPayable.AddAsync(payable1, CancellationToken.None);
        await _repositoryPayable.AddAsync(payable2, CancellationToken.None);
        
        var payables = (await _repositoryPayable.GetByUserIdAsync(userId, CancellationToken.None)).ToList();
        
        Assert.NotNull(payables);
        Assert.Contains(payables, p => p.Id == payable1.Id);
        Assert.Contains(payables, p => p.Id == payable2.Id);
    }
}