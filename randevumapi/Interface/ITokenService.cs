using RandevumAPI.Objects.DTO;
using System.Threading.Tasks;
using Repository.EntitiyModels;

namespace RandevumAPI.Interface
{
    public interface ITokenService
    {
        string GenerateToken(LoginDTO userLoginInfo,string[] roles,int expireTime);
    }
}