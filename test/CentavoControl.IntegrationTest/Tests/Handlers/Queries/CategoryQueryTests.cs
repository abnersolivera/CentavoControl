using CentavoControl.Application.Commands.Category;
using CentavoControl.Application.Queries.Category;
using CentavoControl.Domain.Enums;
using CentavoControl.Infrastructure.Persistence.Repositories;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Queries;

public class CategoryQueryTests : IClassFixture<TestDatabaseFixture>
{
    private readonly ICategoryCommandHandler _categoryCommandHandler;
    private readonly ICategoryQueryHandler _categoryQueryHandler;
    
    public CategoryQueryTests(TestDatabaseFixture fixture)
    {
        ICategoryRepository categoryRepository = new CategoryRepository(fixture.DbContext);
        _categoryCommandHandler = new CategoryCommandHandler(categoryRepository);
        _categoryQueryHandler = new CategoryQueryHandler(categoryRepository);
    }
    
    [Fact]
    public async Task Should_Get_Category_By_UserId()
    {
        // Arrange
        var userId = "0741789C-C8B4-468F-BE98-CC7569D85918";
        var command = new AddCategoryCommand("Test Category","Income");
        await _categoryCommandHandler.AddCategoryAsync(command, CancellationToken.None);
        
        var query = new GetCategoryByUserIdQuery();
        query.SetUserId(userId);
        
        // Act
        var categories = await _categoryQueryHandler.GetCategoriesByUserIdAsync(query, CancellationToken.None);
        
        // Assert
        Assert.NotNull(categories);
        Assert.NotEmpty(categories);
        Assert.All(categories, c => Assert.Equal(userId, c.UserId));
    }
    
    [Fact]
    public async Task Should_Get_Category_By_Id()
    {
        // Arrange
        var command = new AddCategoryCommand("Test Category","Income");
        var addedCategory = await _categoryCommandHandler.AddCategoryAsync(command, CancellationToken.None);
        
        var query = new GetCategoryByIdQuery();
        query.SetId(addedCategory.Id.ToString());
        
        // Act
        var category = await _categoryQueryHandler.GetCategoryByIdAsync(query, CancellationToken.None);
        
        // Assert
        Assert.NotNull(category);
        Assert.Equal(addedCategory.Id, category.Id);
        Assert.Equal("Test Category", category.Name);
        Assert.Equal(Enum.Parse<ETransactionType>("Income"), category.Type);
    }
    
    [Fact]
    public async Task Should_Get_By_Type_And_UserId()
    {
        // Arrange
        var userId = "0741789C-C8B4-468F-BE98-CC7569D85918";
        var commands = new List<AddCategoryCommand>
        {
            new ("Salary", "Income"),
            new ("Freelance", "Income"),
            new ("Groceries", "Expense")
        };
        foreach (var command in commands)
            await _categoryCommandHandler.AddCategoryAsync(command, CancellationToken.None);
        
        var query = new GetCategoryByTypeAndUserIdQuery(userId, nameof(ETransactionType.Income));
        
        // Act
        var categories = (await _categoryQueryHandler.GetCategoriesByTypeAndUserIdAsync(query, CancellationToken.None)).ToList();
        
        // Assert
        Assert.NotNull(categories);
        Assert.NotEmpty(categories);
        Assert.All(categories, c => 
        {
            Assert.Equal(userId, c.UserId);
            Assert.Equal(ETransactionType.Income, c.Type);
        });
    }
}