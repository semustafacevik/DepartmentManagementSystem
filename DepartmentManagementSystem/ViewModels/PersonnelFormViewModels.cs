using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentManagementSystem.Models.EntityFramework;

namespace DepartmentManagementSystem.ViewModels
{
    public class PersonnelFormViewModels
    {
        public tblPersonnel _Personnel { get; set; }
        public IEnumerable<tblDepartment> _Departments { get; set; }
    }
}