using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Instructor
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double salary { get; set; }
        public string?Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }



    }
}
