using API.Template.Default.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Template.Default.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
