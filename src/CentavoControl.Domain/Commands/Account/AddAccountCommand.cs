namespace CentavoControl.Domain.Commands.Account;

public class AddAccountCommand(string name, decimal initialBalance, bool isMainAccount)
{
    public string Name { get; private set; } = name;
    public decimal InitialBalance { get; private set; } = initialBalance;
    public bool IsMainAccount { get; private set; } = isMainAccount;
}