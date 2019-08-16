using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentManagementSystem.Models.EntityFramework;
using DepartmentManagementSystem.ViewModels;
using System.Data.Entity;

namespace DepartmentManagementSystem.Controllers
{
    public class PersonnelController : Controller
    {
        DepartmentManagementDBEntities db = new DepartmentManagementDBEntities();
        
        public ActionResult Index()
        {
            var model = db.tblPersonnel.Include(t => t.tblDepartment).ToList();
            return View(model);
        }

        public ActionResult New()
        {
            PersonnelFormViewModels vm = new PersonnelFormViewModels()
            {
                departments = db.tblDepartment.ToList()
            };

            return View("PersonnelForm",vm);
        }

        public ActionResult Save(tblPersonnel personnel)
        {
            if (personnel.p_ID == 0)
                db.tblPersonnel.Add(personnel);

            else
                db.Entry(personnel).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int ID)
        {
            var model = new PersonnelFormViewModels()
            {
                departments = db.tblDepartment.ToList(),
                personnel = db.tblPersonnel.Find(ID)
            };
            if (model == null)
                return HttpNotFound();
            return View("PersonnelForm",model);
        }

        public ActionResult Delete(int ID)
        {
            var model = db.tblPersonnel.Find(ID);
            if (model == null)
                return HttpNotFound();
            db.tblPersonnel.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}