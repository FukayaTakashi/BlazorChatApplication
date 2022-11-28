using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Helperes;
using System.Security.Cryptography;
using System.Text;

namespace ChatApplication.Domain.Repositories
{
    public sealed class UserRepository
    {
        private readonly IDataRepository _dataRepository;

        public UserRepository(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task AddEntity(UserEntity userEntity)
        {
            userEntity.UserPasswordHash = GetPasswordHash(userEntity.UserPasswordHash);
            var newKeyEncryptionKey = KeyEncryptionKeyEntity.GenerateKey();
            userEntity.KeyEncryptionKeyJson = JsonHelper.Serialize(newKeyEncryptionKey);
            await _dataRepository.AddUserEntity(userEntity);
        }
        public async Task<UserEntity> GetEntity(UserEntity userEntity)
        {
            var foundUserEntity = await _dataRepository.GetUserEntity(userEntity.UserId);
            if (foundUserEntity == null)
            {
                throw new KeyNotFoundException();
            }
            var userPasswordHash = GetPasswordHash(userEntity.UserPasswordHash);
            if (foundUserEntity.UserPasswordHash != userPasswordHash)
            {
                throw new KeyNotFoundException();
            }
            return foundUserEntity;
        }

        private static string GetPasswordHash(string userPassword)
        {
            var userPasswordHash = SHA256.HashData(Encoding.UTF8.GetBytes(userPassword));
            return Convert.ToBase64String(userPasswordHash);
        }
    }
}
