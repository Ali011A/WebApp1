using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class InstructorsController : Controller
    {
        Training_Academy trainingAcademy = new Training_Academy();
        //endpoint url : /Instructors/showAll
        public IActionResult ShowAll()
        {
            var instructorslist = from INS in trainingAcademy.Instructors
                                  join DEP in trainingAcademy.Departments
                                  on INS.DepartmentId equals DEP.id
                                  join course in trainingAcademy.Courses
                                  on INS.CourseId equals course.Id
                                  select new InstructorViewModel
                                  {

                                      Id = INS.id,
                                      Name = INS.Name,
                                      Image = INS.Image,
                                      Salary = INS.salary,
                                      Address = INS.Address,
                                    DepName=  DEP.Name,
                                     CoursName=  course.Name

                                  };

            return View("ShowAll", instructorslist.ToList());
        }

        //endpoint url : /Instructors/show/{id}
        public IActionResult ShowDetails(int id)
        {


            var instructor = (from INS in trainingAcademy.Instructors
                              join DEP in trainingAcademy.Departments
                               on INS.DepartmentId equals DEP.id
                              join course in trainingAcademy.Courses
                              on INS.CourseId equals course.Id
                              where INS.id == id
                              select new InstructorViewModel
                              {

                                  Id = INS.id,
                                  Name = INS.Name,
                                  Image = INS.Image,
                                  Salary = INS.salary,
                                  Address = INS.Address,
                                  DepName = DEP.Name,
                                  CoursName = course.Name
                              }
                            ).FirstOrDefault();

            return View("ShowDetails", instructor);
           
        }
    }
}
