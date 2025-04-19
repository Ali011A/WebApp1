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
                                  CoursName = course.Name,
                                  CourseId= INS.CourseId,
                                  DepartmentId= INS.DepartmentId

                              }
                            ).FirstOrDefault();

            return View("ShowDetails", instructor);
           
        }

        #region AddInstructor
        //endpoint url : /Instructors/Create
        public IActionResult Create()
        {
            ViewBag.Departments = trainingAcademy.Departments.ToList();
            ViewBag.Courses = trainingAcademy.Courses.ToList();
            return View("Create");
        }

        //endpoint url : /Instructors/SaveInstructor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveInstructor(InstructorViewModel ins)
        {
        
            //if(ModelState.IsValid==true)
            // Check if the instructor has valid data
            if (ins.Name != null && ins.Image != null && ins.Salary > 7000 && ins.Address 
                != null && ins.CourseId != 0 && ins.DepartmentId != 0)
            {
               
                trainingAcademy.Instructors.Add(new Instructor
                {
                    Name = ins.Name,
                    Image = ins.Image,
                    salary = ins.Salary,
                    Address = ins.Address,
                    CourseId  = ins.CourseId, 
                    DepartmentId =ins.DepartmentId
                    
                });
                trainingAcademy.SaveChanges();
                return RedirectToAction("ShowAll");

            }
           
           
                ViewBag.Departments = trainingAcademy.Departments.ToList();
                ViewBag.Courses = trainingAcademy.Courses.ToList();
                return View("Create",ins);
            
          
        }
        #endregion

        #region EditInstructor
        //endpoint url : /Instructors/Edit/{id}

        public IActionResult Edit(int id)
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
                                  CoursName = course.Name,
                                  CourseId = INS.CourseId,
                                  DepartmentId = INS.DepartmentId
                              }
                            ).FirstOrDefault();
              ViewBag.Departments = trainingAcademy.Departments.ToList();

            ViewBag.Courses = trainingAcademy.Courses.ToList();
            return View("Edit", instructor);
        }
        [HttpPost]
       
        //endpoint url : /Instructors/EditInstructor
        public IActionResult EditInstructor(InstructorViewModel iTns)
        {

            // Check if the instructor has valid data
            if (iTns.Name != null && iTns.Image != null && iTns.Salary > 7000 && iTns.Address
                != null && iTns.CourseId != 0 && iTns.DepartmentId != 0)
            {
               
                var instructor = trainingAcademy.Instructors.FirstOrDefault(i => i.id == iTns.Id);
                //if (instructor != null)
                //{ }
                    instructor.Name = iTns.Name;
                    instructor.Image = iTns.Image;
                    instructor.salary = iTns.Salary;
                    instructor.Address = iTns.Address;
                    instructor.CourseId = iTns.CourseId;
                    instructor.DepartmentId = iTns.DepartmentId;
                    trainingAcademy.SaveChanges();
                
                return RedirectToAction("ShowAll");
            }
            ViewBag.Departments = trainingAcademy.Departments.ToList();
            ViewBag.Courses = trainingAcademy.Courses.ToList();
            return View("Edit", iTns);


        }

        #endregion
    }
}
