using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CourseController : Controller
    {
        Training_Academy Training_Academy = new Training_Academy();
        // Endpoint url : /Course/Result?cid=1
        public IActionResult Result(int id) 
        {

            var  course = from cr in Training_Academy.CrsResults
                          join tr in Training_Academy.Trainees
                          on cr.TraineeId equals tr.Id
                          join c in Training_Academy.Courses
                          on cr.CourseId equals c.Id
                          where c.Id == id
                          select new CourseViewModel
                          {
                              TraineeName = tr.Name,
                              CourseName = c.Name,
                              Degree = cr.Degree,
                              Status = cr.Degree >= 50 ? "Pass" : "Fail",
                              color = cr.Degree >= 50 ? "green" : "red",
                              Image = tr.image


                          };



            return View( "Result", course.ToList());
        }
        // Endpoint url : /Course/AllCourses
        public IActionResult AllCourses()
        {
            var courses = from C in Training_Academy.Courses
                          join d in Training_Academy.Departments
                            on C.DepartmentId equals d.id
                          select new CourseViewModel
                          {
                              Id = C.Id,
                              CourseName = C.Name,
                              hours = C.hours,
                              minDegree = C.minDegree,
                              Degree = C.degree,
                              DepName = d.Name
                             
                          };

            return View("AllCourses", courses.ToList());
}

        //check minDegree using ajax  
        public IActionResult CheckDegree(int minDegree)
        {
            if (minDegree >= 50)
            {
                return Json("true");
            }
            else
            {
                return Json("false");
            }

        }
        //check Degree Nag using ajax
        public IActionResult CheckDegreeNagative(int Degree)
        {
            if (Degree > 0)
            {
                return Json("true");
            }
            else
            {
                return Json("false");
            }
        }

        #region AddCourse
        // Endpoint url : /Course/AddCourses
        public IActionResult AddCourses()
        {
            CourseViewModel courses= new CourseViewModel();
          courses.DepList = Training_Academy.Departments.ToList();
            return View("AddCourses", courses);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveCourse( CourseViewModel coursess)
        {
            if(coursess.CourseName != null && coursess.DepartmentId != 0 &&
                coursess.hours != 0 && coursess.minDegree != 0 && coursess.minDegree !=0
                )
            {
                Training_Academy.Courses.Add(new Course
                {
                    Name = coursess.CourseName,
                    hours= coursess.hours,
                    minDegree=coursess.minDegree,
                    DepartmentId = coursess.DepartmentId,
                    degree = coursess.Degree
               
                 

                });

                Training_Academy.SaveChanges();
                return RedirectToAction("AllCourses");
            }


            CourseViewModel courseViewModel = new CourseViewModel();
            courseViewModel.DepList = Training_Academy.Departments.ToList();
            return View("AddCourses", courseViewModel);

        }
        #endregion

        #region Edit course
        // Endpoint url : /Course/EditCourse/{id}
        //[HttpPost]
        public IActionResult EditCourse(int id)
        {

            var course = (from C in Training_Academy.Courses
                          join d in Training_Academy.Departments
                          on C.DepartmentId equals d.id
                          where C.Id == id
                          select new CourseViewModel
                          {
                              Id = C.Id,
                              CourseName = C.Name,
                              hours = C.hours,
                              minDegree = C.minDegree,
                              Degree = C.degree,
                              DepName = d.Name,
                              DepartmentId = C.DepartmentId

                          }).FirstOrDefault();
            course.DepList = Training_Academy.Departments.ToList();
            return View("EditCourse", course);
        }

        public IActionResult SEditCourse(CourseViewModel course)
        {


            if (course.CourseName != null && course.DepartmentId != 0 &&
                course.hours != 0 && course.minDegree != 0)
            {
                Training_Academy.Courses.Update(new Course
                {
                    Id = course.Id,
                    Name = course.CourseName,
                    hours = course.hours,
                    minDegree = course.minDegree,
                    DepartmentId = course.DepartmentId,
                    degree = course.Degree
                });
                Training_Academy.SaveChanges();
                return RedirectToAction("AllCourses");



            }
            CourseViewModel courseViewModel = new CourseViewModel();
            courseViewModel.DepList = Training_Academy.Departments.ToList();
            return View("EditCourse", courseViewModel);
       


        }
        #endregion
    }
}
