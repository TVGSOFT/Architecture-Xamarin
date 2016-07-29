using Core.Enums;

namespace Core.Messages
{
    public sealed class NotificationMessage
    {

        #region Properties

        public string Message { get; set; }

        public NotificationType Type { get; set; }

        #endregion

        #region Constructors

        public NotificationMessage(string message, NotificationType type)
        {
            Message = message;
            Type = type;
        }

        #endregion

    }
}
