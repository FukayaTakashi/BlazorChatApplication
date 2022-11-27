using ChatApplication.Domain.Helperes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApplication.Domain.Entities
{
    [Table("ChatRoom")]
    public sealed class ChatRoomJsonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        public int Id { get; set; }
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        public string Data { get; set; } = "[]";

        public void SetData(ChatRoomEntity chatRoomEntity)
        {
            Data = JsonHelper.Serialize(chatRoomEntity);
        }

        public ChatRoomEntity GetEntity()
        {
            return JsonHelper.Deserialize<ChatRoomEntity>(Data);
        }
    }
}