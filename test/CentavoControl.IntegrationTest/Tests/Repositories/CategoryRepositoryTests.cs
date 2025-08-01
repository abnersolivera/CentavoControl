using CentavoControl.Domain.Enums;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Repositories;

public class CategoryRepositoryTests(TestDatabaseFixture fixture) : IClassFixture<TestDatabaseFixture>
{
    private readonly ICategoryRepository _repository = new CategoryRepository(fixture.DbContext);
    
    [Fact]
    public async Task Should_Persist_Category_Correctly()
    {
        var category = new Category(
            Guid.NewGuid(),
            "Test Category",
            ETransactionType.Expense,
            Guid.NewGuid().ToString()
        );

        await _repository.AddAsync(category, CancellationToken.None);

        var loadedCategory = await _repository.GetByIdAsync(category.Id, CancellationToken.None);

        Assert.NotNull(loadedCategory);
        Assert.Equal(category.Id, loadedCategory.Id);
        Assert.Equal(category.Name, loadedCategory.Name);
        Assert.Equal(category.Type, loadedCategory.Type);
        Assert.Equal(category.UserId, loadedCategory.UserId);
    }
    
    [Fact]
    public async Task Should_Update_Category_Correctly()
    {
        var category = new Category(
            Guid.NewGuid(),
            "Test Category",
            ETransactionType.Expense,
            Guid.NewGuid().ToString()
        );

        await _repository.AddAsync(category, CancellationToken.None);

        category.Update("Updated Category", ETransactionType.Income);

        await _repository.UpdateAsync(category, CancellationToken.None);

        var updatedCategory = await _repository.GetByIdAsync(category.Id, CancellationToken.None);

        Assert.NotNull(updatedCategory);
        Assert.Equal("Updated Category", updatedCategory.Name);
        Assert.Equal(ETransactionType.Income, updatedCategory.Type);
    }
    
    [Fact]
    public async Task Should_Delete_Category_Correctly()
    {
        var category = new Category(
            Guid.NewGuid(),
            "Test Category",
            ETransactionType.Expense,
            Guid.NewGuid().ToString()
        );

        await _repository.AddAsync(category, CancellationToken.None);

        await _repository.DeleteAsync(category.Id, CancellationToken.None);

        var deletedCategory = await _repository.GetByIdAsync(category.Id, CancellationToken.None);

        Assert.Null(deletedCategory);
    }
}