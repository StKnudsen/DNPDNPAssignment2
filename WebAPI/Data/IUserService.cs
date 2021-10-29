using System.Threading.Tasks;
using Models;

namespace FileData.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
    }
}