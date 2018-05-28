using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicBox.Models;

namespace MusicBox.Controllers
{
    public class RegisteredUsersController : Controller
    {
        private MusicBoxDBContext db = new MusicBoxDBContext();

        // GET: RegisteredUsers
        public ActionResult Index()
        {
            return View(db.RegisteredUser.ToList());
        }

        // GET: RegisteredUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUser.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisteredUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName,Banned,Username,Password")] RegisteredUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                db.RegisteredUser.Add(registeredUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUser.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName,Banned,Username,Password")] RegisteredUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeredUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUser.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredUser registeredUser = db.RegisteredUser.Find(id);
            db.RegisteredUser.Remove(registeredUser);
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
