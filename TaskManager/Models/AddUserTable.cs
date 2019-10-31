using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class AddUserTable
    {
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Employee_ID { get; set; }
        public int Project_ID { get; set; }
        public int Task_ID { get; set; }

        public  AddProjectTable ProjectTable { get; set; }
        public  AddTaskTable TaskTable { get; set; }
       
    }
}