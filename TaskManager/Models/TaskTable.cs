//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskTable()
        {
            this.UsersTables = new HashSet<UsersTable>();
        }

        public int Task_ID { get; set; }
        public int Parent_ID { get; set; }
        public int Project_ID { get; set; }
        public string Task { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }

        public virtual ParentTaskTable ParentTaskTable { get; set; }
        public virtual ProjectTable ProjectTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersTable> UsersTables { get; set; }
    }
}
