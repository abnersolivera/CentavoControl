using CentavoControl.Application.Commands.Category;
using CentavoControl.Application.Queries.Category;
using CentavoControl.Domain.Enums;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Commands;

public class CategoryCommandHandlerTests : IClassFixture<TestDatabaseFixture>
{
    private readonly ICategoryCommandHandler _categoryCommandHandler;
    private readonly ICategoryQueryHandler _categoryQueryHandler;
    
    public CategoryCommandHandlerTests(TestDatabaseFixture fixture)
    {
        ICategoryRepository categoryRepository = new CategoryRepository(fixture.DbContext);
        _categoryCommandHandler = new CategoryCommandHandler(categoryRepository);
        _categoryQueryHandler = new CategoryQueryHandler(categoryRepository);
    }
    
    [Fact]
    public async Task Should_Add_Category()
    {
        // Arrange
        var command = new AddCategoryCommand("New Category", "Income");
        
        // Act
        var category = await _categoryCommandHandler.AddCategoryAsync(command, CancellationToken.None);
        
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
        var addedCategory = await _categoryCommandHandler.AddCategoryAsync(addCommand, CancellationToken.None);
        
        var updateCommand = new UpdateCategoryCommand("Updated Category", "Expense");
        updateCommand.SetCategoryId(addedCategory.Id.ToString());
        
        // Act
        var updatedCategory = await _categoryCommandHandler.UpdateCategoryAsync(updateCommand, CancellationToken.None);
        
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
        var addedCategory = await _categoryCommandHandler.AddCategoryAsync(addCommand, CancellationToken.None);
        
        var deleteCommand = new DeleteCategoryCommand();
        deleteCommand.SetCategoryId(addedCategory.Id.ToString());
        
        // Act
        await _categoryCommandHandler.DeleteCategoryAsync(deleteCommand, CancellationToken.None);
        var queryCategory = new GetCategoryByIdQuery();
        queryCategory.SetId(addedCategory.Id.ToString());
        var categories = await _categoryQueryHandler.GetCategoryByIdAsync(queryCategory, CancellationToken.None);
        
        // Assert
        Assert.Null(categories);
    }
}