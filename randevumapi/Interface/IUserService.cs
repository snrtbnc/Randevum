using System.Collections.Generic;
using System.Threading.Tasks;
using RandevumAPI.Objects.DTO;
using Repository.EntitiyModels;

namespace RandevumAPI.Interface
{
    public interface IUserService
    {
        Task<string> SaveUser(UserDTO User);
        Task<string> UpdateUser(UserDTO User);
        Task<List<User>> GetUserList();
        Task<List<User>> GetUsersAsync();
        Task<User> GetUser(string Id);
        Task<bool> DeleteUser(string id);
    }
}