using ChatApplication.Domain.Helperes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApplication.Domain.Entities
{
    [Table("Users")]
    public sealed class UserEntity
    {
        private static readonly string _chatRoomIdListSpliter = ", ";
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string UserPasswordHash { get; set; }
        public string UserName { get; set; } = "";
        public string KeyEncryptionKeyJson { get; set; } = "{}";
        public string ChatRoomIdList { get; set; } = "";
        public KeyEncryptionKeyEntity GetKeyEncryptionKey()
        {
            return JsonHelper.Deserialize<KeyEncryptionKeyEntity>(
                KeyEncryptionKeyJson);
        }
        public List<int> GetChatRoomIdList()
        {
            var chatRoomIdStringArray = ChatRoomIdList.Split(_chatRoomIdListSpliter).ToList();
            return chatRoomIdStringArray.ConvertAll(x => int.Parse(x)).ToList();
        }
        public void AddChatRoomIdList(int chatRoomId)
        {
            if (ChatRoomIdList == "")
            {
                ChatRoomIdList += _chatRoomIdListSpliter;
            }
            ChatRoomIdList += chatRoomId;
        }
    }
}
