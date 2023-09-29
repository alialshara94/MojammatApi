namespace MojammatApi.Interfaces
{
    public interface INotificationHub
    {
        Task ReceiveNotification(string user, string title,string description);
    }
}
