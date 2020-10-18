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
        static List<Person> data = new List<Person>() {
            new Person (){Id = 1,Name = "Taiann" ,Age = 40},
            new Person() { Id = 2,Name = "Rency",Age = 38 },
            new Person() { Id = 3,Name = "Toney",Age = 36 },
            new Person() { Id = 4,Name = "John",Age = 34 }
            };
        // GET: Test
        public ActionResult Index()
        {
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                data.Add(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Edit(int id)
        {

            return View(data.FirstOrDefault(p => p.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {

            if (ModelState.IsValid)
            {
                var one = data.FirstOrDefault(p => p.Id == id);
                one.Name = person.Name;
                one.Age = person.Age;
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Delete(int id)
        {

            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Person person)
        {

                //                我自己寫的
                //                var one = data.FirstOrDefault(p => p.Id == id);
                //                data.Remove(one);
                data.Remove(data.FirstOrDefault(p => p.Id == id));
                return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {

            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult Details(int id, Person person)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View(data);
        }
    }
}