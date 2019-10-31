using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class AddParentTask
    {
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }

       
        public  ICollection<TaskTable> TaskTables { get; set; }
    }
}