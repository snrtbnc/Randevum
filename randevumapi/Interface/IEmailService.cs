using System.Threading.Tasks;

namespace RandevumAPI.Interface
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string subject, string message);
    }
}