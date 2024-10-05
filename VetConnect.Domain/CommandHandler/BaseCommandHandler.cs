using VetConnect.Shared.Notifications;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.CommandHandler;

public class BaseCommandHandler
{
    private readonly IUnitOfWork _uow;

    protected IDomainNotification Notifications;

    protected BaseCommandHandler(IUnitOfWork uow, IDomainNotification notifications)
    {
        _uow = uow;
        Notifications = notifications;
    }

    private protected async Task<bool> CommitAsync(bool throwIfFails = true)
    {

        if (Notifications.HasNotifications()) return false;

        if (await _uow.SaveChangesAsync() > 0) return true;

        if (throwIfFails)
            Notifications.Handle("CommonMessages.ProblemSavindData");

        return false;
    }
}