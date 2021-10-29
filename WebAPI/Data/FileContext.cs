using System;
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
        // public IList<Adult> FamiliesToShow { get; private set; }

        private readonly string familiesFile = "families.json";
        // private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            // FamiliesToShow = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
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
            // storing families
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

            /* storing persons
            string jsonAdults = JsonSerializer.Serialize(FamiliesToShow, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
            */
        }
    }
}