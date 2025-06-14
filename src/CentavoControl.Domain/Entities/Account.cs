namespace CentavoControl.Domain.Entities;

public class Account
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public decimal InitialBalance { get; private set; }
    public bool IsMainAccount { get; private set; }
    public string UserId { get; private set; }
    

    public Account(Guid id, string name, decimal initialBalance, bool isMainAccount, string userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        Id = id;
        Name = name;
        InitialBalance = initialBalance;
        IsMainAccount = isMainAccount;
        UserId = userId;
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name cannot be empty.");

        Name = newName;
    }
}
