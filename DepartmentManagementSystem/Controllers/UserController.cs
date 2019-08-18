using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DepartmentManagementSystem.Models.EntityFramework;
using DepartmentManagementSystem.ViewModels;

namespace DepartmentManagementSystem.Controllers
{
    [Authorize(Roles = "1")]
    public class UserController : Controller
    {
        private DepartmentManagementDBEntities db = new DepartmentManagementDBEntities();

        // GET: User
        public ActionResult Index()
        {
            var tblUser = db.tblUser.Include(t => t.tblRole);
            return View(tblUser.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblUser user = db.tblUser.Find(id);
            tblRole role = db.tblRole.Find(user.roleID);

            if (user == null || role == null)
            {
                return HttpNotFound();
            }

            ViewBag.role = role.r_Name;
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.role = new SelectList(db.tblRole, "r_ID", "r_Name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_ID,u_Name,u_Password,roleID")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.tblUser.Add(tblUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.role = new SelectList(db.tblRole, "r_ID", "r_Name", tblUser.roleID);
            return View(tblUser);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUser.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.role = new SelectList(db.tblRole, "r_ID", "r_Name", tblUser.roleID);
            return View(tblUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_ID,u_Name,u_Password,roleID")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.role = new SelectList(db.tblRole, "r_ID", "r_Name", tblUser.roleID);
            return View(tblUser);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser user = db.tblUser.Find(id);
            tblRole role = db.tblRole.Find(user.roleID);

            if (user == null || role == null)
            {
                return HttpNotFound();
            }

            ViewBag.role = role.r_Name;
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUser tblUser = db.tblUser.Find(id);
            db.tblUser.Remove(tblUser);
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
