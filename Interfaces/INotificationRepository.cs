using Microsoft.AspNetCore.SignalR;
using MojammatApi.Helper;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
    public interface INotificationRepository
    {
        bool CreateNotification(PushNotifications pushNotifications);
        ICollection<PushNotifications> GetNotifications(int page, int pageSize, string search);
        PushNotifications GetNotification(Guid id);
        bool DeleteNotification(Guid id);
    }
}
