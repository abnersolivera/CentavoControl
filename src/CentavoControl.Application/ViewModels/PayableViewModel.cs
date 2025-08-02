namespace CentavoControl.Application.ViewModels;

public record PayableViewModel(Guid Id, string Description, decimal Amount, DateTime DueDate, bool IsPaid);