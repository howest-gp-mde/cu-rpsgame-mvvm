using FreshMvvm;
using Mde.Oef.RPSGame.Domain;
using Mde.Oef.RPSGame.Domain.Services;
using Mde.Oef.RPSGame.Infrastructure;
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

            //registreer de application services
            FreshIOC.Container.Register<IGame, Game>();                             //transient

            //registreer de infrastructure services
            FreshIOC.Container.Register<ISettingsService, SettingsService>();       //transient
            FreshIOC.Container.Register<IStatisticsService, StatisticsService>();   //transient

            //2. Resolve je dependencies --> Dependency Injection 

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
