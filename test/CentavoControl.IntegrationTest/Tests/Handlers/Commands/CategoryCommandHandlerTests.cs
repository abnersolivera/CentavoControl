using CentavoControl.Application.Commands.Category;
using CentavoControl.Application.Queries.Category;
using CentavoControl.Domain.Enums;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Commands;

public class CategoryCommandHandlerTests : IClassFixture<TestDatabaseFixture>
{
    private readonly ICategoryCommand _categoryCommand;
    private readonly ICategoryQuery _categoryQuery;
    
    public CategoryCommandHandlerTests(TestDatabaseFixture fixture)
    {
        ICategoryRepository categoryRepository = new CategoryRepository(fixture.DbContext);
        _categoryCommand = new CategoryCommandHandler(categoryRepository);
        _categoryQuery = new CategoryQueryHandler(categoryRepository);
    }
    
    [Fact]
    public async Task Should_Add_Category()
    {
        // Arrange
        var command = new AddCategoryCommand("New Category", "Income");
        
        // Act
        var category = await _categoryCommand.AddCategoryAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(category);
        Assert.Equal("New Category", category.Name);
        Assert.Equal(Enum.Parse<ETransactionType>("Income"), category.Type);
    }
    
    [Fact]
    public async Task Should_Update_Category()
    {
        // Arrange
        var addCommand = new AddCategoryCommand("Test Category", "Income");
        var addedCategory = await _categoryCommand.AddCategoryAsync(addCommand, CancellationToken.None);
        
        var updateCommand = new UpdateCategoryCommand("Updated Category", "Expense");
        updateCommand.SetCategoryId(addedCategory.Id.ToString());
        
        // Act
        var updatedCategory = await _categoryCommand.UpdateCategoryAsync(updateCommand, CancellationToken.None);
        
        // Assert
        Assert.NotNull(updatedCategory);
        Assert.Equal("Updated Category", updatedCategory.Name);
        Assert.Equal(updateCommand.ParseType(), updatedCategory.Type);
    }
    
    [Fact]
    public async Task Should_Delete_Category()
    {
        // Arrange
        var addCommand = new AddCategoryCommand("Test Category", "Income");
        var addedCategory = await _categoryCommand.AddCategoryAsync(addCommand, CancellationToken.None);
        
        var deleteCommand = new DeleteCategoryCommand();
        deleteCommand.SetCategoryId(addedCategory.Id.ToString());
        
        // Act
        await _categoryCommand.DeleteCategoryAsync(deleteCommand, CancellationToken.None);
        var queryCategory = new GetCategoryByIdQuery();
        queryCategory.SetId(addedCategory.Id.ToString());
        var categories = await _categoryQuery.GetCategoryByIdAsync(queryCategory, CancellationToken.None);
        
        // Assert
        Assert.Null(categories);
    }
}