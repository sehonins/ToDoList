using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.Model
{
    public interface ITaskDatabase
    {
        Task<IEnumerable<TaskToDo>> GetTasksToDo();
        Task<bool> SaveTask(TaskToDo task);
        Task<bool> UpdateTask(TaskToDo task);
        Task<bool> DeleteTask(TaskToDo task);
    }
}
