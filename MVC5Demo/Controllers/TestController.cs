using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var data = new List<Person>() {
            new Person (){Id = 1,Name = "Taiann" ,Age = 40},
            new Person() { Id = 1,Name = "Rency",Age = 38 },
            new Person() { Id = 1,Name = "Toney",Age = 36 },
            new Person() { Id = 1,Name = "John",Age = 34 }
            };


            return View(data);
        }
    }
}