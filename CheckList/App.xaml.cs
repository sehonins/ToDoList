using CheckList.Model;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckList
{
    public partial class App : Application
    {
        private static TaskDatabase taskDatabase;

        public static TaskDatabase TaskDatabase
        {
            get
            { 
                if (taskDatabase == null)
                {
                    taskDatabase = new TaskDatabase(Path.Combine
                        (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"taskDB.db3"));
                }
                return taskDatabase;
            }   
        }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
