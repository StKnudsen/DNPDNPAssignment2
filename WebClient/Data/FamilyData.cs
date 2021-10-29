using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace FileData
{
    public class FamilyData : IFamilyData
    {
        
       
        public async Task<List<Family>> GetFamilyAsync()
        {
            using HttpClient client = new HttpClient();
            Console.WriteLine("TEST");
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/Family");
            Console.WriteLine("Reached GetFamilyAsync");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Family> families = JsonSerializer.Deserialize<List<Family>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return families;
        }

        public void AddAdult(Adult adult, string streetName)
        {
            //Family family = GetFamilyAsync().First(street => street.StreetName.Equals(streetName));
            //family.Adults.Add(adult);
            //_fileContext.SaveChanges();
        }
        

        
    }
}