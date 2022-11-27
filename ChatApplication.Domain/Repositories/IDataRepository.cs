using ChatApplication.Domain.Entities;

namespace ChatApplication.Domain.Repositories
{
    public interface IDataRepository
    {
        Task AddUserEntity(UserEntity userEntity);
        Task<UserEntity?> GetUserEntity(string userId);
        Task<List<UserEntity>> GetUserEntities();
        Task AddChatRoomEntity(ChatRoomEntity chatRoomEntity);
        Task<ChatRoomEntity> GetChatRoomEntity(int chatRoomId);
        Task<List<ChatRoomEntity>> GetChatRoomEntities(List<int> chatRoomIdList);
    }
}
