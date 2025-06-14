namespace CentavoControl.UnitTest.Tests.DomainTests;

public class AccountTests
{
    [Fact]
    public void Constructor_ValidParameters_ShouldCreateAccount()
    {
        var id = Guid.NewGuid();
        var account = new Account(id, "Conta Corrente", 1000m, true, "user1");
        Assert.Equal(id, account.Id);
        Assert.Equal("Conta Corrente", account.Name);
        Assert.Equal(1000m, account.InitialBalance);
        Assert.True(account.IsMainAccount);
        Assert.Equal("user1", account.UserId);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidName_ShouldThrow(string name)
    {
        Assert.Throws<ArgumentException>(() => new Account(Guid.NewGuid(), name, 0, false, "user1"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidUserId_ShouldThrow(string userId)
    {
        Assert.Throws<ArgumentException>(() => new Account(Guid.NewGuid(), "Conta", 0, false, userId));
    }

    [Fact]
    public void ChangeName_Valid_ShouldChangeName()
    {
        var account = new Account(Guid.NewGuid(), "Conta", 0, false, "user1");
        account.ChangeName("Nova Conta");
        Assert.Equal("Nova Conta", account.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ChangeName_Invalid_ShouldThrow(string newName)
    {
        var account = new Account(Guid.NewGuid(), "Conta", 0, false, "user1");
        Assert.Throws<ArgumentException>(() => account.ChangeName(newName));
    }
}