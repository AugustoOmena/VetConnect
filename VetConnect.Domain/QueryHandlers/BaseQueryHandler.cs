using VetConnect.Shared.Notifications;

namespace VetConnect.Domain.QueryHandlers;

public class BaseQueryHandler
{
    protected IDomainNotification Notifications;

    public BaseQueryHandler(IDomainNotification notifications)
    {
        Notifications = notifications;
    }
}