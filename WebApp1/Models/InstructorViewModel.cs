using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class InstructorViewModel
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(30)   ]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [RegularExpression(@"\w*\.(jpg|jpeg|png)") ]
        public string Image { get; set; }
        [Range(7000, 50000, ErrorMessage = "Salary must be between 7000 and 50000")]
        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [MinLength(3), MaxLength(30)]
        public string Address { get; set; }
        
        public int CourseId { get; set; }
        public string CoursName { get; set; }
        public int DepartmentId { get; set; }
        public string DepName { get; set; }
    }
}
