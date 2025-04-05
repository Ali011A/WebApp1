using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CourseController : Controller
    {
        Training_Academy Training_Academy = new Training_Academy();
        // Endpoint url : /Course/Result?cid=1
        public IActionResult Result(int cid) 
        {

            var  course = from cr in Training_Academy.CrsResults
                          join tr in Training_Academy.Trainees
                          on cr.TraineeId equals tr.Id
                          join c in Training_Academy.Courses
                          on cr.CourseId equals c.Id
                          where c.Id == cid
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
    }
}
