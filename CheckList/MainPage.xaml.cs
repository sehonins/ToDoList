using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CheckList.Model;

namespace CheckList
{
    public partial class MainPage : ContentPage
    {
        TaskToDo selectedTask;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.TaskDatabase.GetTasksToDo();
        }
        private async void BtnDelite_Clicked(object sender, EventArgs e)
        {
            if (selectedTask != null)
            {
                await App.TaskDatabase.DeleteTask(selectedTask);
                RefreshList();
                CleanScreen();
            }
            else
            {
                DisplayAlert
            ("Warning", "Please choose task to delete", "Ok");
            }

        }
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if(selectedTask != null)
            {
                selectedTask.TaskDescription = entryTask.Text;
                selectedTask.IsDone = isDone.IsChecked;
                await App.TaskDatabase.UpdateTask(selectedTask);

                RefreshList();
            }
            else
            {
                DisplayAlert
              ("Warning", "Please choose task to update", "Ok");

            }

        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryTask.Text))
            {
                await App.TaskDatabase.SaveTask(new TaskToDo 
                {
                    TaskDescription = entryTask.Text,
                    IsDone = isDone.IsChecked
                });
                RefreshList();
                CleanScreen();
            }
            else
            {
              DisplayAlert
              ("Warning", "Description can't be empty", "Ok");
            }

        }

        private void CleanScreen()
        {
            entryTask.Text = String.Empty;
            isDone.IsChecked = false;
        }
        private async void RefreshList()
        {
            collectionView.ItemsSource = await 
                App.TaskDatabase.GetTasksToDo();
        }

        
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTask = e.CurrentSelection[0] as TaskToDo;
            
            entryTask.Text = selectedTask.TaskDescription;
            isDone.IsChecked = selectedTask.IsDone;
        }
    }
}
