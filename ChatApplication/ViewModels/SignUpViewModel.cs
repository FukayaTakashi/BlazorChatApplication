using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Repositories;

namespace ChatApplication.ViewModels
{
    public sealed class SignUpViewModel
    {
        private readonly UserRepository _userRepository;

        public SignUpViewModel(IDataRepository dataRepository)
        {
            _userRepository = new(dataRepository);
        }

        public UserEntity FormUserEntity { get; set; } = new();

        public async Task SignUp()
        {
            var addingUserEntity = new UserEntity()
            {
                UserId = FormUserEntity.UserId,
                UserName = FormUserEntity.UserName,
                UserPasswordHash = FormUserEntity.UserPasswordHash
            };
            await _userRepository.AddEntity(addingUserEntity);
        }
    }
}
