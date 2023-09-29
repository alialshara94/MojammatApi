using Microsoft.AspNetCore.SignalR;
using MojammatApi.Helper;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;

namespace MojammatApi.Repositories
{
    public class NotificationRepository : INotificationRepository
    {

        private readonly AppDbContext appDbContext;
        public NotificationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool CreateNotification(PushNotifications pushNotifications)
        {
            appDbContext.notifications.Add(pushNotifications);
            return appDbContext.SaveChanges() > 0;
        }

        public bool DeleteNotification(Guid id)
        {
            var notification = appDbContext.notifications.Find(id);
            if (notification == null)
            {
                return false;
            }
            appDbContext.notifications.Remove(notification);
            return appDbContext.SaveChanges() > 0;
        }

        public PushNotifications GetNotification(Guid id)
        {
            return appDbContext.notifications.Where(u => u.id == id).FirstOrDefault();
        }

        public ICollection<PushNotifications> GetNotifications(int page, int pageSize, string search)
        {
            IQueryable<PushNotifications> query = appDbContext.notifications;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u => u.title.Contains(search));
            }
            query = query.OrderBy(n => n.createdAt);
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
