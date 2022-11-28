using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Repositories;

namespace ChatApplication.ViewModels
{
    public sealed class ChatRoomViewModel
    {
        private readonly ChatRoomRepository _chatRoomRepository;
        private readonly ChatRoomEntity _chatRoomEntity;
        private readonly UserEntity _loginedUserEntity;
        private readonly EncryptionKeyEntity _encryptionKeyEntity;
        public ChatRoomViewModel(IDataRepository dataRepository, UserEntity loginedUserEntity, int chatRoomId)
        {
            _chatRoomRepository = new ChatRoomRepository(dataRepository);
            _chatRoomEntity = _chatRoomRepository.GetEntity(chatRoomId).Result;
            _loginedUserEntity = loginedUserEntity;
            var keyEncryptionKeyEntity = _loginedUserEntity.GetKeyEncryptionKey();

            _encryptionKeyEntity = _chatRoomEntity.EncryptedEncryptionKeyList.GetEncryptionKeyEntity(keyEncryptionKeyEntity);
        }
        public List<ChatDataEntity> ChatDataEntities { get; set; } = new();
    }
}
