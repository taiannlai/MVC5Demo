using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class DepartmentsController : Controller
    {
        ContosoUniversityEntities1 db = new ContosoUniversityEntities1();
        // GET: Departments
        public ActionResult Index()
        {

            return View(db.Department.ToList());
        }

    }
}