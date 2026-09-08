using Microsoft.Toolkit.Uwp.Notifications;
using SL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace SL.Services
{
    /// <summary>
    /// Brinda el servicio de notificaciones de Windows ("Toast Notification").
    /// </summary>
    public static class SystemNotificationService
    {
        public static void Trigger(SystemNotification toastNotification)
        {
            ToastContentBuilder contentBuilder = new ToastContentBuilder();
            contentBuilder.AddText(toastNotification.Title);

            if (toastNotification.Description != null)
                contentBuilder.AddText(toastNotification.Description);

            if (!toastNotification.ExpirationTime.HasValue)
                contentBuilder.Show();
            else
            {
                DateTimeOffset ExpirationDate = DateTime.Now.Add((TimeSpan)toastNotification.ExpirationTime);
                contentBuilder.Show(toast => { toast.ExpirationTime = ExpirationDate; });
            }
        }
        public static void Schedule(SystemNotification toastNotification, DateTime ScheduledDate)
        {
            ToastContentBuilder contentBuilder = new ToastContentBuilder();
            contentBuilder.AddText(toastNotification.Title);

            if (toastNotification.Description != null)
                contentBuilder.AddText(toastNotification.Description);

            if (!toastNotification.ExpirationTime.HasValue)
                contentBuilder.Schedule(ScheduledDate);
            else
            {
                DateTimeOffset ExpirationDate = DateTime.Now.Add((TimeSpan)toastNotification.ExpirationTime);
                contentBuilder.Schedule(ScheduledDate, toast => { toast.ExpirationTime = ExpirationDate; });
            }
        }
        public static void Unschedule(SystemNotification toastNotification)
        {
            ToastNotifierCompat notifier = ToastNotificationManagerCompat.CreateToastNotifier();

            IReadOnlyList<ScheduledToastNotification> scheduledToasts = notifier.GetScheduledToastNotifications();

            var toRemove = scheduledToasts;
            foreach (var item in toRemove)
            {
                if (item.Content.InnerText == toastNotification.Title + toastNotification.Description)
                    notifier.RemoveFromSchedule(item);
            }
        }
        public static void Unschedule(string Title)
        {
            ToastNotifierCompat notifier = ToastNotificationManagerCompat.CreateToastNotifier();

            IReadOnlyList<ScheduledToastNotification> scheduledToasts = notifier.GetScheduledToastNotifications();

            var toRemove = scheduledToasts;
            foreach (var item in toRemove)
            {
                if (item.Content.InnerText == Title)
                    notifier.RemoveFromSchedule(item);
            }
        }
        public static void Unschedule(string Title, string Description)
        {
            ToastNotifierCompat notifier = ToastNotificationManagerCompat.CreateToastNotifier();

            IReadOnlyList<ScheduledToastNotification> scheduledToasts = notifier.GetScheduledToastNotifications();

            var toRemove = scheduledToasts;
            foreach (var item in toRemove)
            {
                if (item.Content.InnerText == Title + Description)
                    notifier.RemoveFromSchedule(item);
            }
        }

        /// <summary>
        /// Bloque de datos que posee la información para disparar una notificación de Windows.
        /// </summary>
        public class SystemNotification
        {
            string _Title;
            string _Description;
            TimeSpan? _ExpirationTime;

            public SystemNotification(string title)
            {
                Title = title;
            }
            public SystemNotification(string title, string description)
            {
                Title = title;
                Description = description;
            }
            public SystemNotification(string title, string description, TimeSpan expirationTime)
            {
                Title = title;
                Description = description;
                ExpirationTime = expirationTime;
            }

            public string Title { get => _Title; set => _Title = value; }
            public string Description { get => _Description; set => _Description = value; }
            public TimeSpan? ExpirationTime { get => _ExpirationTime; set => _ExpirationTime = value; }
        }
    }
}
