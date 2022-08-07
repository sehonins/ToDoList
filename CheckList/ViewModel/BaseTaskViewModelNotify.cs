using CheckList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CheckList.ViewModel
{
    internal class BaseTaskViewModelNotify : INotifyPropertyChanged
    {
       
        private TaskToDo _taskToDo;

        public TaskToDo TaskToDo 
        { 
            get  { return _taskToDo; }
            set { _taskToDo = value; OnPropertyChange(); }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }

        

        protected bool SetProperty<T>(ref T backingTask, T value,
         [CallerMemberName] string propertyName = "", Action onChange = null)
        {
            if(EqualityComparer<T>.Default.Equals(backingTask, value))
                return false;

            backingTask = value;
            onChange?.Invoke();
            OnPropertyChange(propertyName);
            return true;
        }
            


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange([CallerMemberName] string propertyName = "")
        {
            var change = PropertyChanged;
            if (change == null)
                return;

            change?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
