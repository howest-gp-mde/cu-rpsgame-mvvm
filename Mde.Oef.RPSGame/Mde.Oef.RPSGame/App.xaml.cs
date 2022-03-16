using FreshMvvm;
using Mde.Oef.RPSGame.Pages;
using Mde.Oef.RPSGame.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mde.Oef.RPSGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FreshNavigationContainer(
                FreshPageModelResolver.ResolvePageModel<MainViewModel>()
            );
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
