using CheckList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckList.ViewModel
{
    internal class TaskViewModel
    {
        public ObservableCollection<TaskToDo> TaskColection { get; set; }


        //    //Constructor
        //    public TaskViewModel()
        //    {
        //        TaskColection = new ObservableCollection<TaskToDo>();
        //        TaskColection.Add(new TaskToDo
        //         { TaskDescription = "First",  IsDone = IsDone });

        //        SaveDataCommand = new Command(async () => await SaveData(),
        //                                            () => !IsBusy);
        //        RemoveDataCommand = new Command(async () => await RemoveData(),
        //                                            () => !IsBusy);
        //        UpdateDataCommand = new Command(async () => await UpdateData());
        //    }

        //    // TODO Do not change
        //    #region  
        //    //Fields
        //    TaskToDo selectedTask;
        //    string description = "New Task";
        //    List<TaskToDo> tasks;
        //    bool isDone = false;
        //    bool isBusy = false;



        //    //Proporties
        //    public TaskToDo SelectedTask
        //    {
        //        get => selectedTask;
        //        set
        //        {
        //            if (SelectedTask != value)
        //            {
        //                selectedTask = value;
        //            }
        //        }
        //    }
        //    public string TaskDescription
        //    {
        //        get { return description; } 
        //        set
        //        {
        //            description = value;
        //        }
        //    }
        //    public bool IsDone
        //    {
        //        get { return isDone; }
        //        set
        //        {
        //            isDone = value;

        //        }
        //    }
        //    public bool IsBusy
        //    {
        //        get { return isBusy; }
        //        set
        //        {
        //            isBusy = value;
        //        }
        //    }


        //    public Command SaveDataCommand { get; }
        //    public Command RemoveDataCommand { get; }
        //    public Command UpdateDataCommand { get; }
        //    #endregion No need to change

        //    //Methodes
        //    async Task SaveData()
        //    {
        //        if (!string.IsNullOrWhiteSpace(TaskDescription))
        //        {
        //            await App.TaskDatabase.SaveTask(new TaskToDo
        //            {
        //                TaskDescription = TaskDescription,
        //                IsDone = IsDone
        //            });
        //            TaskColection.Add(new TaskToDo
        //            {
        //                TaskDescription = TaskDescription,
        //                IsDone = IsDone
        //            });

        //        };

        //    }
        //    async Task RemoveData()
        //    {
        //        if (selectedTask != null)
        //        {
        //            // await App.TaskDatabase.DeleteTask(selectedTask);
        //            TaskColection.Remove(selectedTask);
        //        };
        //    }
        //    async Task UpdateData()
        //    {

        //        if (selectedTask != null)
        //        {
        //            //selectedTask.TaskDescription = TaskDescription;
        //            //selectedTask.IsDone = IsDone;
        //            //await App.TaskDatabase.UpdateTask(selectedTask);

        //        }
        //    }


        // 
    }
   
}
