namespace CentavoControl.Domain.DTOs;

public class AccountDto(Guid id, string name, decimal initialBalance, bool isMainAccount, string userId)
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public decimal InitialBalance { get; init; } = initialBalance;
    public bool IsMainAccount { get; init; } = isMainAccount;
    public string UserId { get; init; } = userId;
}