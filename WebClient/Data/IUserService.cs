
using Shared.Models;

namespace WebClient.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}