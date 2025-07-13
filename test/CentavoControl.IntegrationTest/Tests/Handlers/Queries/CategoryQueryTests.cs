using CentavoControl.Application.Commands.Category;
using CentavoControl.Application.Queries.Category;
using CentavoControl.Domain.Enums;

namespace CentavoControl.IntegrationTest.Tests.Handlers.Queries;

public class CategoryQueryTests : IClassFixture<TestDatabaseFixture>
{
    private readonly ICategoryCommand _categoryCommand;
    private readonly ICategoryQuery _categoryQuery;
    
    public CategoryQueryTests(TestDatabaseFixture fixture)
    {
        ICategoryRepository categoryRepository = new CategoryRepository(fixture.DbContext);
        _categoryCommand = new CategoryCommandHandler(categoryRepository);
        _categoryQuery = new CategoryQueryHandler(categoryRepository);
    }
    
    [Fact]
    public async Task Should_Get_Category_By_UserId()
    {
        // Arrange
        var userId = "0741789C-C8B4-468F-BE98-CC7569D85918";
        var command = new AddCategoryCommand("Test Category","Income");
        await _categoryCommand.AddCategoryAsync(command, CancellationToken.None);
        
        var query = new GetCategoryByUserIdQuery();
        query.SetUserId(userId);
        
        // Act
        var categories = await _categoryQuery.GetCategoriesByUserIdAsync(query, CancellationToken.None);
        
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
        var addedCategory = await _categoryCommand.AddCategoryAsync(command, CancellationToken.None);
        
        var query = new GetCategoryByIdQuery();
        query.SetId(addedCategory.Id.ToString());
        
        // Act
        var category = await _categoryQuery.GetCategoryByIdAsync(query, CancellationToken.None);
        
        // Assert
        Assert.NotNull(category);
        Assert.Equal(addedCategory.Id, category.Id);
        Assert.Equal("Test Category", category.Name);
        Assert.Equal(Enum.Parse<ETransactionType>("Income"), category.Type);
    }
}