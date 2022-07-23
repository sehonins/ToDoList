using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CheckList.Model
{
    public class TaskDatabase
    {
        private readonly SQLiteAsyncConnection _taskDB;

        public TaskDatabase(string dbPath)
        {
            _taskDB = new SQLiteAsyncConnection(dbPath);
            _taskDB.CreateTableAsync<TaskToDo>();
        }

        public Task<List<TaskToDo>> GetTasksToDo()
        {
            return _taskDB.Table<TaskToDo>().ToListAsync(); 
        }
        public Task<int> SaveTask(TaskToDo task)
        {
            return _taskDB.InsertAsync(task);
        }
        public Task<int> UpdateTask(TaskToDo task)
        {
            return _taskDB.UpdateAsync(task);
        }
        public Task<int> DeleteTask(TaskToDo task)
        {
            return _taskDB.DeleteAsync(task);
        }
        //Reference only
        public Task<List<TaskToDo>> QueryAsync()
        {
            return _taskDB.QueryAsync<TaskToDo>("SELECt * FROM TaskToDo WHERE" +
                "isDone = true");
        }

        public Task<List<TaskToDo>> LinqAsync()
        {
            return _taskDB.Table<TaskToDo>().Where(x => x.Id == 1).ToListAsync();   
        }
    }
}
