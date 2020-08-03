using API.Templa.Default.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Templa.Default.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
