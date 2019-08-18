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
    [Authorize(Roles = "1,2")]
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
                departments = db.tblDepartment.ToList(),
                personnel = new tblPersonnel()
            };

            return View("PersonnelForm",vm);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(tblPersonnel personnel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonnelFormViewModels()
                {
                    departments = db.tblDepartment.ToList(),
                    personnel = personnel
                };
                return View("PersonnelForm", model);

            }
            if (personnel.p_ID == 0)
            {
                personnel.p_IsActive = true;
                db.tblPersonnel.Add(personnel);
            }
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

        public ActionResult ShowPersonnelsInDepartment(int ID, string name)
        {
            var model = db.tblPersonnel.Where(m => m.departmentID == ID);
            ViewBag.Department = name;
            return View(model);
        }
    }
}