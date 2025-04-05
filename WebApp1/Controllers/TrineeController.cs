using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class TrineeController : Controller
    {


        Training_Academy trainingAcademy = new Training_Academy();

        //Endpoint url : /Trinee/Result?tid=1&cid=1
       public IActionResult Result(int tid,int cid) 
        {
            var trinee = from tr in trainingAcademy.Trainees
                         join cr in trainingAcademy.CrsResults
                         on tr.Id equals cr.TraineeId
                         join c in trainingAcademy.Courses
                         on cr.CourseId equals c.Id
                         where tr.Id == tid && c.Id == cid
                         select new TraineeViewModel
                         {
                             TraineeName = tr.Name,
                             CourseName = c.Name,
                             Degree = cr.Degree,
                             Status =cr.Degree >=50 ? "Pass" : "Fail",
                             color = cr.Degree >= 50 ? "green" : "red",
                             Image = tr.image

                         };


            return View( "Result", trinee.FirstOrDefault() );
        }


    }
}
