using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? image { get; set; }
        
        public string? Address { get; set; }
        public int? Grade { get; set; } // grade
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
