using Microsoft.AspNetCore.SignalR;
using MojammatApi.Interfaces;

namespace MojammatApi.Hubs
{
    public class NotificationHub : Hub<INotificationHub>
    {
        //public override async Task OnConnectedAsync()
        //{
        //  await Clients.All.ReceiveNotification($"{Context.ConnectionId} has joind");
        //}

        public async Task SendMessage(string user, string title, string description)
        {
            await Clients.All.ReceiveNotification($"{Context.ConnectionId} : {user} ",title,description);
        }
    }
}
