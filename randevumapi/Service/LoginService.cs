using RandevumAPI.Interface;
using RandevumAPI.Objects;
using RandevumAPI.Objects.CustomExceptions;
using RandevumAPI.Objects.DTO;
using Repository;
using Repository.EntitiyModels;
using System.Threading.Tasks;


namespace RandevumAPI.Service
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        //private readonly IEmailService _emailService;

        private readonly IMongoRepository<User> _userRepository;
        public LoginService(ITokenService tokenService, IEmailService emailService, IMongoRepository<User> userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }
        public async Task<UserDTO> Login(LoginDTO loginInfo)
        {
            var user = await _userRepository.FindOneAsync(x => x.Email == loginInfo.Email && x.Password == loginInfo.Password);
            UserDTO userResult = new UserDTO();
            
            if(user == null)
                 throw new ServiceException("invalid username or password"); 
                 
            if (user != null)
            {
                userResult.Name = user.Name;
                userResult.BirthDate = user.BirthDate;
                userResult.Email = user.Email;
                userResult.Surname = userResult.Surname;
                userResult.Token = _tokenService.GenerateToken(loginInfo, user.Roles, 7);
            }

            return userResult;
        }
    }
}