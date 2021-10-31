using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData.Data;
using Models;

namespace FileData.Impl
{
    public class  InMemoryUserService: IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User()
                {
                    Password = "123456",
                    UserName = "Troels"
                },
                new User()
                {
                    Password = "Otto2021",
                    UserName = "Tina"
                },
                new User()
                {
                Password = "password",
                UserName = "username"
                }
            }.ToList();
        }

        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }   
    }
}