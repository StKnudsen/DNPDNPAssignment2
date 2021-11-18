using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shared.Models;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ViaDbContext dbContext = new ViaDbContext())
            {
                if (!dbContext.Users.Any())
                {
                    SeedUsers(dbContext);
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static void SeedUsers(ViaDbContext dbContext)
        {
            //IList<User> users = new List<User>();
            dbContext.Add(new User()
                {
                    Password = "123456",
                    UserName = "Troels"
                });
            dbContext.Add(new User()
            {
                    Password = "Otto2021",
                    UserName = "Tina"
                });
            //dbContext.Add(users);
            dbContext.SaveChanges();
        }
    }
}