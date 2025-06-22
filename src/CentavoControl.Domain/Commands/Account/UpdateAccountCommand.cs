namespace CentavoControl.Domain.Commands.Account;

public class UpdateAccountCommand(string name)
{
    private Guid _id;

    public string Name { get; private set; } = name;

    public void SetAccountId(string accountId) => _id = Guid.Parse(accountId);
    public Guid GetAccountId() => _id;
}