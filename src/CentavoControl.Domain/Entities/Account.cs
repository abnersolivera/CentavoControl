namespace CentavoControl.Domain.Entities;

public class Account
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public decimal InitialBalance { get; init; }
    public bool IsMainAccount { get; init; }
    public string UserId { get; init; }
    public ICollection<Payable>? Payables { get; private set; }


    protected Account()
    {
        
    }
    
    public Account(Guid id, string name, decimal initialBalance, bool isMainAccount, string userId, ICollection<Payable>? payables = null)
    {
        Id = id;
        Name = name;
        InitialBalance = initialBalance;
        IsMainAccount = isMainAccount;
        UserId = userId;
        Payables = payables ?? new List<Payable>();
    }

    public void ChangeName(string newName)
    {
        Name = newName;
    }
}
