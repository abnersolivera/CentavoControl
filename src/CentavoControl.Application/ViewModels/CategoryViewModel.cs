using CentavoControl.Domain.Enums;

namespace CentavoControl.Application.ViewModels;

public record CategoryViewModel(Guid Id, string Name, ETransactionType Type, string UserId);