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
    public class CourseController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        //
        // GET: /course/

        public ActionResult Index()
        {
            return View(db.course.ToList());
        }

        //
        // GET: /course/Details/5

        public ActionResult Details(int id = 0)
        {
            course course = db.course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /course/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /course/Create

        [HttpPost]
        public ActionResult Create(course course)
        {
            if (ModelState.IsValid)
            {
                db.course.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        //
        // GET: /course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            course course = db.course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /course/Edit/5

        [HttpPost]
        public ActionResult Edit(course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        //
        // GET: /course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            course course = db.course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /course/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            course course = db.course.Find(id);
            db.course.Remove(course);
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