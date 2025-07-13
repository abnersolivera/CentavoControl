using CentavoControl.Domain.Enums;

namespace CentavoControl.UnitTest.Tests.DomainTests;

public class CategoryTests
{
    [Fact]
    public void Constructor_ValidParameters_ShouldCreateCategory()
    {
        var id = Guid.NewGuid();
        var category = new Category(id, "Alimentação", ETransactionType.Expense, "user1");
        Assert.Equal(id, category.Id);
        Assert.Equal("Alimentação", category.Name);
        Assert.Equal(ETransactionType.Expense, category.Type);
        Assert.Equal("user1", category.UserId);
    }

    [Fact]
    public void Update_ValidParameters_ShouldUpdateCategory()
    {
        var id = Guid.NewGuid();
        var category = new Category(id, "Alimentação", ETransactionType.Expense, "user1");
        category.Update("Transporte Urbano", ETransactionType.Expense);
        Assert.Equal("Transporte Urbano", category.Name);
        Assert.Equal(ETransactionType.Expense, category.Type);
    }
}