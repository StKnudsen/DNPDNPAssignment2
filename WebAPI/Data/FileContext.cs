using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace WebAPI.Data
{
    public class FileContext
    {
        private IList<Family> Families;

        private readonly string familiesFile = "families.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(familiesFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            return Families;
        }

        public async Task SaveChangesAsync(Adult adult, string streetName)
        {
            Family family = Families.First(f => f.StreetName.Equals(streetName));
            family.Adults.Add(adult);
            
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }
        }
    }
}