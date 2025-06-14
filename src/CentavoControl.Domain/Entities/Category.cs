namespace CentavoControl.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ETransactionType Type { get; private set; }
    public string UserId { get; private set; }

    private Category()
    {
        
    }
    public Category(Guid id, string name, ETransactionType type, string userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        
        if (!Enum.IsDefined(typeof(ETransactionType), type))
            throw new ArgumentException("Invalid type.", nameof(type));

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        Id = id;
        Name = name;
        Type = type;
        UserId = userId;
    }
}