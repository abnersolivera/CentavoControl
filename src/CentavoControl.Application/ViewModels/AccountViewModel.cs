namespace CentavoControl.Application.ViewModels;

public record AccountViewModel(Guid Id, string Name, decimal InitialBalance, bool IsMainAccount, string UserId);