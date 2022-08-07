using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CheckList.Model
{
    public class TaskDatabase : ITaskDatabase
    {
        private readonly SQLiteAsyncConnection _taskDB;

        public TaskDatabase(string dbPath)
        {
            _taskDB = new SQLiteAsyncConnection(dbPath);
            _taskDB.CreateTableAsync<TaskToDo>();
        }

        public async Task<IEnumerable<TaskToDo>> GetTasksToDo()
        {
            return await Task.FromResult(await _taskDB.Table<TaskToDo>().ToListAsync());
        }
        public async Task<bool> SaveTask(TaskToDo task)
        {
            _taskDB.InsertAsync(task);
            return await Task.FromResult(true); 
        }

        public async Task<bool> UpdateTask(TaskToDo task)
        {
             _taskDB.UpdateAsync(task);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteTask(TaskToDo task)
        {
             _taskDB.DeleteAsync(task);
            return Task.FromResult(true);
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
