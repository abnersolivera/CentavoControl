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

    [Fact]
    public void ChangeName_Valid_ShouldChangeName()
    {
        var account = new Account(Guid.NewGuid(), "Conta", 0, false, "user1");
        account.ChangeName("Nova Conta");
        Assert.Equal("Nova Conta", account.Name);
    }
}