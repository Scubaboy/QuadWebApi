using Microsoft.AspNet.SignalR;

namespace QuadWebApi.SignalRHubs.NotifyUpdate
{
    public class NotifyUpdateHub : Hub
    {
        public void DataUpdateNotification(string updateType, string updateScope)
        {
            if (updateScope == "All")
            {
                Clients.All.dataChanged(updateType);
            }
            else
            {
                Clients.Others.dataChanged(updateType);
            }
        }
    }
}