using MahApps.Metro.Controls;
using Notifications.Wpf;
using Notifications.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;


namespace Mail_Record_Application.UI
{
    class Notification
    {
            private static Notification notification = new Notification();
            private Notification() { }

            public static Notification giveInstance()
            {
                return notification;
            }

            public void successNotifier(string message)
            {
                var notificationManager = new NotificationManager();

                notificationManager.Show(new NotificationContent
                {
                    Title = "Success",
                    Message = message,
                    Type = NotificationType.Success
                });
            }

            public void errorNotifier(string message)
            {
                var notificationManager = new NotificationManager();

                notificationManager.Show(new NotificationContent
                {
                    Title = "Error",
                    Message = message,
                    Type = NotificationType.Error
                });
            }

            public async void MessageDialog(MetroWindow window, string title, string message)
            {
                await window.ShowMessageAsync(title, message);
            }
    }
}
