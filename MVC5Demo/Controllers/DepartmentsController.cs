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
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person.Where(c => c.Discriminator == "Instructor"), "ID", "FirstName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Person.Where(c => c.Discriminator == "Instructor"), "ID", "FirstName");
            return View(department);
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            ViewBag.InstructorID = new SelectList(db.Person.Where(c => c.Discriminator == "Instructor"), "ID", "FirstName");

            return View(db.Department.Find(id.Value));
        }
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(id);

                item.Name = department.Name;
                item.Budget = department.Budget;
                item.StartDate = department.StartDate;
                item.InstructorID = department.InstructorID;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Person.Where(c => c.Discriminator == "Instructor"), "ID", "FirstName");

            return View(db.Department.Find(id));
        }
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Person.Where(c => c.Discriminator == "Instructor"), "ID", "FirstName");

            return View(db.Department.Find(id.Value));
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var item = db.Department.Single(c => c.DepartmentID == id);
            if (ModelState.IsValid)
            {

                db.Department.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person.Where(c => c.Discriminator == "Instructor"), "ID", "FirstName");

            return View(db.Department.Find(id));
        }
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            return View(db.Department.Find(id.Value));
        }
        [HttpPost]
        public ActionResult Detials(int? id, Department department)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View(department);
        }
    }
}