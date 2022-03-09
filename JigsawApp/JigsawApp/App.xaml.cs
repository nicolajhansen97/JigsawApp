using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JigsawApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            // MainPage = new MenuScreen();
            MainPage = new NavigationPage(new FrontPage());
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
