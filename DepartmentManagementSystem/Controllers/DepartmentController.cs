using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentManagementSystem.Models.EntityFramework;

namespace DepartmentManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManagementDBEntities db = new DepartmentManagementDBEntities();

        // GET: Department
        public ActionResult Index()
        {
            var model = db.tblDepartment.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("DepartmentForm");
        }


        public ActionResult Save(tblDepartment department)
        {
            if (department.d_ID == 0)
                db.tblDepartment.Add(department);

            else
            {
                var upDepartment = db.tblDepartment.Find(department.d_ID);
                if (upDepartment == null)
                    return HttpNotFound();

                upDepartment.d_Name = department.d_Name;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int ID)
        {
            var model = db.tblDepartment.Find(ID);
            if (model == null)
                return HttpNotFound();
            return View("DepartmentForm", model);
        }

        public ActionResult Delete(int ID)
        {
            var model = db.tblDepartment.Find(ID);
            if (model == null)
                return HttpNotFound();

            db.tblDepartment.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}