//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DepartmentManagementSystem.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblDepartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDepartment()
        {
            this.tblPersonnel = new HashSet<tblPersonnel>();
        }
        
        public int d_ID { get; set; }

        [Display(Name = "Department Name")]
        [Required]
        public string d_Name { get; set; }

        [Display(Name = "Department Activity Status")]
        [Required]
        public bool d_IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPersonnel> tblPersonnel { get; set; }
    }
}
