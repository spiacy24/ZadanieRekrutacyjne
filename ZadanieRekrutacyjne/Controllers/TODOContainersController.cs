using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Controllers
{
    public class TODOContainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TODOContainers
        public ActionResult Index()
        {
            return View(db.ToDoBase.ToList());
        }

        // GET: TODOContainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODOContainer tODOContainer = db.ToDoBase.Find(id);
            if (tODOContainer == null)
            {
                return HttpNotFound();
            }
            return View(tODOContainer);
        }

        // GET: TODOContainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TODOContainers/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Group,Tag,RemindDate,IsDone")] TODOContainer tODOContainer)
        {
            if (ModelState.IsValid)
            {
                string IDcurrentUser = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x=> x.Id ==IDcurrentUser);
                tODOContainer.User = currentUser;

                db.ToDoBase.Add(tODOContainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tODOContainer);
        }

        // GET: TODOContainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODOContainer tODOContainer = db.ToDoBase.Find(id);
            if (tODOContainer == null)
            {
                return HttpNotFound();
            }
            return View(tODOContainer);
        }

        // POST: TODOContainers/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Group,Tag,RemindDate,IsDone")] TODOContainer tODOContainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tODOContainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tODOContainer);
        }

        // GET: TODOContainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODOContainer tODOContainer = db.ToDoBase.Find(id);
            if (tODOContainer == null)
            {
                return HttpNotFound();
            }
            return View(tODOContainer);
        }

        // POST: TODOContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TODOContainer tODOContainer = db.ToDoBase.Find(id);
            db.ToDoBase.Remove(tODOContainer);
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
