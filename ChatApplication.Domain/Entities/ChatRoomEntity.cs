namespace ChatApplication.Domain.Entities
{
    public sealed class ChatRoomEntity
    {
        public EncryptedEncryptionKeyList EncryptedEncryptionKeyList { get; set; } = new();

        public EncryptedChatDataList EncryptedChatDataList { get; set; } = new();
    }
}