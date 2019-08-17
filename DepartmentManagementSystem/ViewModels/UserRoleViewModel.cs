using DepartmentManagementSystem.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentManagementSystem.ViewModels
{
    public class UserRoleViewModel
    {
        public tblRole _Role { get; set; }
        public tblUser _User { get; set; }
    }
}