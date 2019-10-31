using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class AddTaskTable
    {
        public int Task_ID { get; set; }
        public int Parent_ID { get; set; }
        public int Project_ID { get; set; }
        public string Task { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }




        public ParentTaskTable ParentTaskTable { get; set; }
        public  ProjectTable ProjectTable { get; set; }
       
        public  ICollection<UsersTable> UsersTables { get; set; }

    }
}