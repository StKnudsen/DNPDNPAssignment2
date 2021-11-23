using System.Threading.Tasks;
using Shared.Models;

namespace WebAPI.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
    }
}