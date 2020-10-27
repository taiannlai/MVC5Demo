using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class ReportsController : Controller
    {
        ContosoUniversityEntities1 db = new ContosoUniversityEntities1();

        StringBuilder sb = new StringBuilder();
        // GET: Reports
        public ReportsController()
        {
            db.Database.Log = (msg) =>
            {
                sb.AppendLine(msg);
                sb.AppendLine("---------------------------------");
            };
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CoursesReport1()
        {
            var data = (from c in db.Course
                       select new CoursesReport1VM
                       {
                           CourseID = c.CourseID,
                           CourseName = c.Title,
                           StudentCount = c.Enrollments.Count(),
                           TeacherCount = c.Teachers.Count(),
                           AvgGrade = c.Enrollments.Where(e => e.Grade.HasValue).Average(e => e.Grade.Value)
                       }).ToString();

            ViewBag.SQL = sb.ToString();

            return View(data);
        }
        public ActionResult CoursesReport2()
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"Select Course.CourseID, Course.Title AS CourseName,
	        (SELECT COUNT(CourseID)  From CourseInstructor WHERE (CourseID = Course.CourseID)) AS TeacherCount,
	        (SELECT COUNT(CourseID)  From Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS StudentCount,
	        (SELECT AVG(Cast(Grade as Float)) From Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS AvgGrade
            FROM Course
            ").ToList();

            ViewBag.SQL = sb.ToString();

            return View("CoursesReport1", data);
        }
        public ActionResult CoursesReport3(int id)
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"Select Course.CourseID, Course.Title AS CourseName,
	        (SELECT COUNT(CourseID)  From CourseInstructor WHERE (CourseID = Course.CourseID)) AS TeacherCount,
	        (SELECT COUNT(CourseID)  From Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS StudentCount,
	        (SELECT AVG(Cast(Grade as Float)) From Enrollment WHERE (Course.CourseID = Enrollment.CourseID)) AS AvgGrade
            FROM Course
            WHERE Course.CourseID = @p0
            ", id).ToList();
            ViewBag.SQL = sb.ToString();
            return View("CoursesReport1", data);
        }
        public ActionResult CoursesReport4(int id)
        {
            var data = db.GetCourseReport(id).First();
            ViewBag.SQL = sb.ToString();
            return View(data);
        }
        public ActionResult CoursesReport5(int id)
        {
            var data = db.Database.SqlQuery<GetCourseReport_Result>("EXEC GetCourseReport @p0", id).First();
            ViewBag.SQL = sb.ToString();
            return View("CoursesReport4", data);
        }
    }
}