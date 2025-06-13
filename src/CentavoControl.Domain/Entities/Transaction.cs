using CentavoControl.Domain.Enums;

namespace CentavoControl.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public ETransactionType Type { get; private set; }
    public DateTime Date { get; private set; }

    public Guid AccountId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string UserId { get; private set; }

    public Transaction(
        Guid id,
        string description,
        decimal amount,
        ETransactionType type,
        DateTime date,
        Guid accountId,
        Guid categoryId,
        string userId)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        Id = id;
        Description = description;
        Amount = amount;
        Type = type;
        Date = date;
        AccountId = accountId;
        CategoryId = categoryId;
        UserId = userId;
    }
}