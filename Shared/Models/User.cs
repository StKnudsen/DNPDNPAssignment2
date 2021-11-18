using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}