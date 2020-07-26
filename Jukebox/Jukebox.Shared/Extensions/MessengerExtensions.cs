using GalaSoft.MvvmLight.Messaging;
using System;

namespace Jukebox.Shared.Extensions
{
    public static class MessengerExtensions
    {
        public static void RegisterMessageListener<T>(
            this IMessenger messenger,
            object listener,
            string messageId,
            Action<NotificationMessage<T>> methodName)
        {
            messenger.Register<NotificationMessage<T>>(listener, (object)messageId, methodName, false);
        }

        public static void RegisterMessageListener(
            this IMessenger messenger,
            object listener,
            string messageId,
            Action<NotificationMessage> methodName)
        {
            messenger.Register<NotificationMessage>(listener, (object)messageId, methodName, false);
        }

        public static void SendMessage<T>(
            this IMessenger messenger,
            T message,
            string messageId,
            object contentId = null,
            object receiver = null)
        {
            if (contentId != null && receiver != null)
                messenger.Send<NotificationMessage<T>>(new NotificationMessage<T>(contentId, receiver, message, messageId), (object)messageId);
            else if (contentId != null)
                messenger.Send<NotificationMessage<T>>(new NotificationMessage<T>(contentId, message, messageId), (object)messageId);
            else
                messenger.Send<NotificationMessage<T>>(new NotificationMessage<T>(message, messageId), (object)messageId);
        }

        public static void SendMessage(
            this IMessenger messenger,
            string messageId,
            object contentId = null,
            object receiver = null)
        {
            if (contentId != null && receiver != null)
                messenger.Send<NotificationMessage>(new NotificationMessage(contentId, receiver, messageId), (object)messageId);
            else if (contentId != null)
                messenger.Send<NotificationMessage>(new NotificationMessage(contentId, messageId), (object)messageId);
            else
                messenger.Send<NotificationMessage>(new NotificationMessage(messageId), (object)messageId);
        }
    }
}
