using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData
{
    public interface IFamilyData
    {
        Task<List<Family>> GetFamilyAsync();
        Task AddAdult(Adult adult, string streetName);
        //void RemovePerson();
        
        
    }
}