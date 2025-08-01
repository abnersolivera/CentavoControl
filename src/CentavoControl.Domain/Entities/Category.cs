namespace CentavoControl.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ETransactionType Type { get; private set; }
    public string UserId { get; private set; }
    public ICollection<Payable>? Payables { get; private set; }

    protected Category()
    {
        
    }
    
    public Category(Guid id, string name, ETransactionType type, string userId, ICollection<Payable>? payables = null)
    {
        Id = id;
        Name = name;
        Type = type;
        UserId = userId;
        Payables = payables ?? new List<Payable>();
    }
    
    public void Update(string name, ETransactionType type)
    {
        Name = name;
        Type = type;
    }
}