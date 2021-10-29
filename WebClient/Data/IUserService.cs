using Models;

namespace FileData.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}