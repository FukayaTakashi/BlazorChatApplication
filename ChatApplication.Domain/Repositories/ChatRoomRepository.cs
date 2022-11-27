using ChatApplication.Domain.Entities;

namespace ChatApplication.Domain.Repositories
{
    public sealed class ChatRoomRepository
    {
        private readonly IDataRepository _dataRepository;

        public ChatRoomRepository(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task Add(ChatRoomEntity chatRoomEntity)
        {
            await _dataRepository.AddChatRoomEntity(chatRoomEntity);
        }

        public async Task<ChatRoomEntity> GetEntity(int chatRoomId)
        {
            return await _dataRepository.GetChatRoomEntity(chatRoomId);
        }

        public async Task<List<ChatRoomEntity>> GetEntities(List<int> chatRoomIdList)
        {
            return await _dataRepository.GetChatRoomEntities(chatRoomIdList);
        }
    }
}
