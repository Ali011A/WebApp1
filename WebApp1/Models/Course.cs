using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public int degree { get; set; }//  degree
        public int minDegree { get; set; }  //minDegree
        public int hours { get; set; } //hours
        [ForeignKey("Department") ]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
