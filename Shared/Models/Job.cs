using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Job
    {
        [Key]
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}