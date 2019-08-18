using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentManagementSystem.Models.EntityFramework;

namespace DepartmentManagementSystem.ViewModels
{
    public class PersonnelFormViewModels
    {
        public tblPersonnel personnel { get; set; }
        public IEnumerable<tblDepartment> departments { get; set; }
    }
}