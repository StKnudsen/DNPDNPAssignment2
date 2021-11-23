using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace WebClient.Data
{
    public interface IFamilyData
    {
        Task<List<Family>> GetFamilyAsync();
        Task AddAdult(Adult adult, string streetName);
        //void RemovePerson();
        
        
    }
}