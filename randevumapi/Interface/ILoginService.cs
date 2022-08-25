using RandevumAPI.Objects.DTO;
using System.Threading.Tasks;
using Repository.EntitiyModels;

namespace RandevumAPI.Interface
{
    public interface ILoginService
    {
        Task<UserDTO> Login(LoginDTO loginInfo);
    }
}