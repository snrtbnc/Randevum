using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RandevumAPI.Interface;
using RandevumAPI.Objects.DTO;
using Repository;
using Repository.EntitiyModels;

namespace RandevumAPI.Service
{
    public class UserService : IUserService
    {

        private readonly IMongoRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMongoRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<User> GetUser(string id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public Task<List<User>> GetUserList()
        {
            return Task.FromResult(new List<User>());
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.ToListAsync();
        }

        public async Task<string> SaveUser(UserDTO User)
        {
            User newUser = new User();
            newUser = _mapper.Map<User>(User);

            await _userRepository.InsertOneAsync(newUser);

            return newUser.Id.ToString();
        }

        public async Task<string> UpdateUser(UserDTO User)
        {
            User newUser = new User();
            newUser = _mapper.Map<User>(User);

            await _userRepository.ReplaceOneAsync(newUser);

            return newUser.Id.ToString();
        }

        public async Task<bool> DeleteUser(string id)
        {
            return await _userRepository.DeleteByIdAsync(id);
        }

    }
}