using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class CourseManagemantController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        //
        // GET: /CourseManagemant/

        public ActionResult Index()
        {
            return View(db.CourseManagemants.ToList());
        }

        //
        // GET: /CourseManagemant/Details/5

        public ActionResult Details(int id = 0)
        {
            CourseManagemants coursemanagemants = db.CourseManagemants.Find(id);
            if (coursemanagemants == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagemants);
        }

        //
        // GET: /CourseManagemant/Create

        public ActionResult Create()
        {
            var classe = db.Classe.ToList();
            ViewBag.Classe = classe;

            var teachers = db.Teachers.ToList();
            ViewBag.Teachers = teachers;

            var course = db.course.ToList();
            ViewBag.course = course;

            return View();
        }

        //
        // POST: /CourseManagemant/Create

        [HttpPost]
        public ActionResult Create(CourseManagemants coursemanagemants)
        {
            if (ModelState.IsValid)
            {
                db.CourseManagemants.Add(coursemanagemants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemanagemants);
        }

        //
        // GET: /CourseManagemant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CourseManagemants coursemanagemants = db.CourseManagemants.Find(id);
            if (coursemanagemants == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagemants);
        }

        //
        // POST: /CourseManagemant/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseManagemants coursemanagemants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemanagemants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemanagemants);
        }

        //
        // GET: /CourseManagemant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CourseManagemants coursemanagemants = db.CourseManagemants.Find(id);
            if (coursemanagemants == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagemants);
        }

        //
        // POST: /CourseManagemant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseManagemants coursemanagemants = db.CourseManagemants.Find(id);
            db.CourseManagemants.Remove(coursemanagemants);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}