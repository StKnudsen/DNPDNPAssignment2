using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models {
public class Family {
    
    public string StreetName { get; set; }
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }
}


}