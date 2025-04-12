using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string? TraineeName { get; set; }
        [Display(Name = "Course Name")]
        public string? CourseName { get; set; } // CourseName
        public int Degree { get; set; } // Degree
        public string? Status { get; set; }
        public string? color { get; set; }
        public string? Image { get; set; } // Image
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        
        public string? DepName { get; set; } // Department Name
        public List<Department>? DepList { get; set; } // list of departments
        [Display(Name = " minamum degree")]
        public int minDegree { get; set; }
        [Display(Name = "Course hours")]
        public int hours { get; set; } // hours

    }
}
