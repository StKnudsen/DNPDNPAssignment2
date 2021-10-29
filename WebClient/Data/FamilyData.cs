using System.Collections.Generic;
using System.Linq;
using Models;

namespace FileData
{
    public class FamilyData : IFamilyData
    {
        private FileContext _fileContext = new FileContext();
       
        public IList<Family> GetFamily()
        {
            return _fileContext.Families;
        }

        public void AddAdult(Adult adult, string streetName)
        {
            Family family = GetFamily().First(street => street.StreetName.Equals(streetName));
            family.Adults.Add(adult);
            _fileContext.SaveChanges();
        }
        

        
    }
}