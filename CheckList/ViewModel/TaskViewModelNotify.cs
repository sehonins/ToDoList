using CheckList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckList.ViewModel
{
    internal class TaskViewModelNotify : BaseTaskViewModelNotify
    {
        public Command LoadDataComand { get; set; }
        public Command SaveDataCommand { get; }
        public ObservableCollection<TaskToDo> TasksToDo { get; set; }

        public Command RemoveDataCommand { get; }
        public Command UpdateDataCommand { get; }

        // TODO Do not change
        //Fields
        TaskToDo selectedTask;
        string description = "New Task";
        List<TaskToDo> tasks;
        bool isDone = false;



        //Proporties
        public TaskToDo SelectedTask
        {
            get => selectedTask;
            set
            {
                if (SelectedTask != value)
                {
                    selectedTask = value;
                }
            }
        }
        public string TaskDescription
        {
            get { return description; }
            set
            {
                description = value;
            }
        }
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                isDone = value;

            }
        }

        public TaskViewModelNotify()
        {
            LoadDataComand = new Command(async () => await ExecuteLoadDataComand());
            TasksToDo = new ObservableCollection<TaskToDo>();


            SaveDataCommand = new Command(SaveData);
            RemoveDataCommand = new Command(RemoveData);
            UpdateDataCommand = new Command(async () => await UpdateData());
        }
        public void OnAppearing()
        {

            IsBusy = false;
            ExecuteLoadDataComand();
        }

        async Task ExecuteLoadDataComand()
        {
            IsBusy = true;
            try
            {
                TasksToDo.Clear();
                var taskList = await App.TaskDatabase.GetTasksToDo();
                foreach (var task in taskList)
                {
                    TasksToDo.Add(task);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
            
        }

        async void SaveData()
        {
            await App.TaskDatabase.SaveTask(new TaskToDo
            {
                TaskDescription = TaskDescription,
                IsDone = IsDone
            });
            ExecuteLoadDataComand();
        }


        async void RemoveData()
        {
            if (selectedTask != null)
            {
              await App.TaskDatabase.DeleteTask(selectedTask);
            };
            await ExecuteLoadDataComand();

        }


        async Task UpdateData()
        {
            if (selectedTask != null)
            {
                await App.TaskDatabase.UpdateTask(selectedTask);
            }
            ExecuteLoadDataComand();
        }
    }
}
