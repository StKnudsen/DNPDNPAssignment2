using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace WebAPI.Data.Impl
{
    public class SqliteUserService : IUserService
    {
        private ViaDbContext DbContext;

        public SqliteUserService(ViaDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            List<User> users = new List<User>();
            users = await DbContext.Users.ToListAsync();
            
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