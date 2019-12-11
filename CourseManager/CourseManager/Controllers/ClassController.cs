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
    public class ClassController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        //
        // GET: /Class/

        public ActionResult Index()
        {
            return View(db.Classe.ToList());
        }

        //
        // GET: /Class/Details/5

        public ActionResult Details(int id = 0)
        {
            Classe Classe = db.Classe.Find(id);
            if (Classe == null)
            {
                return HttpNotFound();
            }
            return View(Classe);
        }

        //
        // GET: /Class/Create

        public ActionResult Create()
        {
            var teacher = db.Teachers.ToList();
            ViewBag.Teachers = teacher;
            return View();
        }

        //
        // POST: /Class/Create

        [HttpPost]
        public ActionResult Create(Classe Classe)
        {
            if (ModelState.IsValid)
            {
                db.Classe.Add(Classe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Classe);
        }

        //
        // GET: /Class/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var teacher = db.Teachers.ToList();
            ViewBag.Teachers = teacher;
            Classe Classe = db.Classe.Find(id);
            if (Classe == null)
            {
                return HttpNotFound();
            }

            return View(Classe);
        }

        //
        // POST: /Class/Edit/5

        [HttpPost]
        public ActionResult Edit(Classe Classe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Classe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Classe);
        }

        //
        // GET: /Class/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Classe Classe = db.Classe.Find(id);
            if (Classe == null)
            {
                return HttpNotFound();
            }
            return View(Classe);
        }

        //
        // POST: /Class/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Classe Classe = db.Classe.Find(id);
            db.Classe.Remove(Classe);
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