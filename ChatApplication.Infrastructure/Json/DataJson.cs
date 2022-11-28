using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Repositories;
using System.Net.Http.Json;

namespace ChatApplication.Infrastructure.Sqlite
{
    public sealed class DataJson : IDataRepository
    {
        private readonly HttpClient _httpClient;

        public DataJson(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddUserEntity(UserEntity userEntity)
        {
            var users = await GetUserEntities();
            users.Add(userEntity);
            await _httpClient.PostAsJsonAsync(
                $"user/users.json",
                users);
        }

        public async Task<UserEntity?> GetUserEntity(string userId)
        {
            var users = await GetUserEntities();
            return users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public async Task<List<UserEntity>> GetUserEntities()
        {
            return await _httpClient.GetFromJsonAsync<List<UserEntity>>(
                $"data/users.json") ?? new();
        }

        public Task AddChatRoomEntity(ChatRoomEntity chatRoomEntity)
        {
            throw new NotImplementedException();
        }

        public Task<ChatRoomEntity> GetChatRoomEntity(int chatRoomId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatRoomEntity>> GetChatRoomEntities(List<int> chatRoomIdList)
        {
            throw new NotImplementedException();
            //var foundChatRoomEntities = new List<ChatRoomEntity>();
            //foreach (var chatRoomId in chatRoomIdList)
            //{
            //    var foundChatRoomEntity = ;
            //    if (foundChatRoomEntity == null)
            //    {
            //        throw new KeyNotFoundException();
            //    }
            //    foundChatRoomEntities.Add(foundChatRoomEntity);
            //}
            //return foundChatRoomEntities;
        }
    }
}
