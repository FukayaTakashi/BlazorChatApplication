using ChatApplication.Domain.Helperes;

namespace ChatApplication.Domain.Entities
{
    public sealed class ChatDataEntity
    {
        public ChatDataEntity(string sendUserId, DateTime sendDateTime, string message)
        {
            SendUserId = sendUserId;
            SendDateTime = sendDateTime;
            Message = message;
        }

        public string SendUserId { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Message { get; set; }
    }
}
