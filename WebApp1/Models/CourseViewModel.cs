using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace WebApp1.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        //[Remote(action: "CheckName", controller: "Course")  ]
        [MinLength(3, ErrorMessage = "Course name must be at least 3 characters long.") ]
        [MaxLength(30, ErrorMessage = "Course name must be at most 30 characters long.")]
        public string? TraineeName { get; set; }
        [Display(Name = "Course Name")]
        [Required (ErrorMessage = "Course name is required")]
        public string? CourseName { get; set; } // CourseName

        [Remote(action: "CheckDegreeNagative", controller: "Course")]
        public int Degree { get; set; } // Degree
        public string? Status { get; set; }
        public string? color { get; set; }
        //[Display(Name = "Course Image")]
        [RegularExpression(@"\w*\.(jpg|jpeg|png)", ErrorMessage = "Image must be in jpg, jpeg or png format")]
        public string? Image { get; set; } // Image
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        

        public string? DepName { get; set; } // Department Name
        public List<Department>? DepList { get; set; } // list of departments
        [Display(Name = " minamum degree")]
        [Remote(action: "CheckDegree", controller: "Course")]
        public int minDegree { get; set; }
        [Display(Name = "Course hours")]
        [Range(78, 300, ErrorMessage = "Course hours must be between 78 and 100")]
        public int hours { get; set; } // hours

    }
}
