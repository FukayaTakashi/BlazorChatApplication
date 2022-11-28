using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Repositories;
using System.Net.Http.Headers;

namespace ChatApplication.ViewModels
{
    public class SignInViewModel
    {
        private readonly UserRepository _userRepository;

        public SignInViewModel(IDataRepository dataRepository)
        {
            _userRepository = new(dataRepository);
        }

        public UserEntity FormUserEntity { get; set; } = new();

        public async Task<UserEntity> SignIn()
        {
            var signInUserEntity = new UserEntity()
            {
                UserId = FormUserEntity.UserId,
                UserPasswordHash = FormUserEntity.UserPasswordHash
            };
            return await _userRepository.GetEntity(signInUserEntity);
        }
    }
}
