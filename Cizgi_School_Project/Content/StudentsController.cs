using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cizgi_School_Project.Models;

namespace Cizgi_School_Project.Content
{
    public class StudentsController : Controller
    {
        // GET: Students
        CizgiSchoolDbEntities db = new CizgiSchoolDbEntities();
        public ActionResult Index()
        {
            var values= db.StudentsTable.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentsTable p)
        {
            db.StudentsTable.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteStudent(int id)
        {
            var values = db.StudentsTable.Find(id);
            db.StudentsTable.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}