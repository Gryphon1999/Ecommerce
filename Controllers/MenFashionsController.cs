using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.DAL;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class MenFashionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MenFashions
        public ActionResult Index()
        {
            return View(db.menFashions.ToList());
        }

        // GET: MenFashions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenFashion menFashion = db.menFashions.Find(id);
            if (menFashion == null)
            {
                return HttpNotFound();
            }
            return View(menFashion);
        }

        // GET: MenFashions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenFashions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,Type,Size,Color")] MenFashion menFashion)
        {
            if (ModelState.IsValid)
            {
                db.menFashions.Add(menFashion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menFashion);
        }

        // GET: MenFashions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenFashion menFashion = db.menFashions.Find(id);
            if (menFashion == null)
            {
                return HttpNotFound();
            }
            return View(menFashion);
        }

        // POST: MenFashions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,Type,Size,Color")] MenFashion menFashion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menFashion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menFashion);
        }

        // GET: MenFashions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenFashion menFashion = db.menFashions.Find(id);
            if (menFashion == null)
            {
                return HttpNotFound();
            }
            return View(menFashion);
        }

        // POST: MenFashions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenFashion menFashion = db.menFashions.Find(id);
            db.menFashions.Remove(menFashion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
