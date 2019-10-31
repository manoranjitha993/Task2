using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class AddProjectTable
    {
        public int Project_ID { get; set; }
        public string Project { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Priority { get; set; }


       
        public ICollection<TaskTable> TaskTables { get; set; }
       
        public  ICollection<UsersTable> UsersTables { get; set; }


    }
}