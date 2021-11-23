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
        public static async Task Main(string[] args)
        {
            using (ViaDbContext dbContext = new ViaDbContext())
            {
                if (!dbContext.Users.Any())
                {
                    SeedUsers(dbContext);
                }
                
                if (!dbContext.Families.Any())
                {
                    await SeedFamilies(dbContext);
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => 
                    { webBuilder.UseStartup<Startup>(); });

        private static void SeedUsers(ViaDbContext dbContext)
        {
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
            
            dbContext.SaveChanges();
        }


        private static async Task SeedFamilies(ViaDbContext dbContext)
        {
            FileContext fileContext = new FileContext();

            IList<Family> families = await fileContext.GetFamiliesAsync();
            Console.WriteLine("Help");

            foreach (Family family in families)
            {
                await dbContext.Families.AddAsync(
                    new Family()
                    {
                        Id = family.Id,
                        HouseNumber = family.HouseNumber,
                        StreetName = family.StreetName,
                        Adults = family.Adults
                    }
                );
                await dbContext.SaveChangesAsync();
                Console.WriteLine(family.StreetName);
            }
        }

        private static async Task SeedJobs(ViaDbContext dbContext)
        {
            FileContext fileContext = new FileContext();

            IList<Family> families = await fileContext.GetFamiliesAsync();

            foreach (Family family in families)
            {
                foreach (Adult adult in family.Adults)
                {
                    if (adult.Job is not null)
                    {
                        Console.WriteLine("Jobcenter");
                        await dbContext.Jobs.AddAsync(
                            new Job()
                            {
                                JobTitle = adult.Job.JobTitle,
                                Salary = adult.Job.Salary
                            }
                        );
                        Console.WriteLine("Doooooonk");
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}