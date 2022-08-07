using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CheckList.Model;
using Xamarin.Essentials;
using CheckList.ViewModel;
using System.Collections.ObjectModel;

namespace CheckList
{
    public partial class MainPage : ContentPage
    {
        TaskViewModelNotify taskViewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = taskViewModel = new TaskViewModelNotify();  
        }
        protected override  void OnAppearing()
        {
           base.OnAppearing();
            taskViewModel.OnAppearing();
        }


        // TODO: Delete later

       // private  void ViewBtn_Clicked(object sender, EventArgs e)
       // {
       //    // ResfreshList();
       // }

       //public async void ResfreshList()
       // {
       //     collectionView.ItemsSource = taskViewModel.TasksToDo.ToList();
       // }
    }
}
