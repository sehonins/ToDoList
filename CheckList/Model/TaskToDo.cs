using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckList.Model
{
    public class TaskToDo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; }    
    }
}
