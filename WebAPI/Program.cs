using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shared.Models;
using WebAPI.Data;

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

                if (!dbContext.Families.Any())
                {
                    SeedFamilies(dbContext);
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

        private static async Task SeedFamilies(ViaDbContext dbContext)
        {
            FileContext fileContext = new FileContext();

            IList<Family> families = await fileContext.GetFamiliesAsync();
            Console.WriteLine();

            foreach (Family family in families)
            {
                await dbContext.Families.AddAsync(new Family
                {
                    Id = family.Id,
                    HouseNumber = family.HouseNumber,
                    StreetName = family.StreetName,
                    Adults = family.Adults
                });

                await dbContext.SaveChangesAsync();
                Console.WriteLine(family.StreetName);

                // foreach (Adult adult in family.Adults)
                // {
                //     dbContext.Add(new Adult
                //     {
                //         Age = adult.Age,
                //         EyeColor = adult.EyeColor,
                //         FirstName = adult.FirstName,
                //         HairColor = adult.HairColor,
                //         Height = adult.Height,
                //         Id = adult.Id,
                //         LastName = adult.LastName,
                //         Sex = adult.Sex,
                //         Weight = adult.Weight,
                //         Job = adult.Job,
                //         Family = family
                //     });
                //
                //     Console.WriteLine("  " + adult.LastName);
                // }
            }

            //await dbContext.SaveChangesAsync();
        }
    }
}