using CentavoControl.Domain.Enums;

namespace CentavoControl.UnitTest.Tests.DomainTests;

public class PayableTests
{
    [Fact]
    public void Constructor_ValidParameters_ShouldCreateAccount()
    {
        // Arrange
        var id = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        var account = new Account(Guid.NewGuid(), "Test Account", 0.00m, true, userId);
        var category = new Category(Guid.NewGuid(), "Test Category", ETransactionType.Income, userId);
        
        var payable = new Payable(
        
            id,
            "Test Payable",
            100.00m,
            DateTime.Now.AddDays(30),
            account.Id,
            category.Id,
            userId,
            account,
            category
            )
        ;

        // Act & Assert
        Assert.Equal(id, payable.Id);
        Assert.Equal("Test Payable", payable.Description);
        Assert.Equal(100.00m, payable.Amount);
        Assert.False(payable.IsPaid);
        Assert.True(payable.DueDate > DateTime.Now);
    }
}