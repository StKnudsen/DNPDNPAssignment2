using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/Family");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Family> families = JsonSerializer.Deserialize<List<Family>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return families;
        }

        public async Task AddAdult(Adult adult, string streetName)
        {
            using HttpClient client = new HttpClient();

            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage =
                await client.PutAsync($"https://localhost:5001/Family?streetName={streetName}", content);
        }
        

        
    }
}