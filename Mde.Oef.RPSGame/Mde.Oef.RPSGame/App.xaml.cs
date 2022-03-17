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
            //registreer de application services
            FreshIOC.Container.Register<IGame, Game>().AsMultiInstance();                             //transient

            //registreer de infrastructure services
            FreshIOC.Container.Register<ISettingsService, SettingsService>().AsMultiInstance();       //transient
            FreshIOC.Container.Register<IStatisticsService, StatisticsService>().AsMultiInstance();   //transient


            InitializeComponent();

            //MainPage = new FreshNavigationContainer(
            //    FreshPageModelResolver.ResolvePageModel<MainViewModel>()
            //);
            var flyoutContainer = new FreshMasterDetailNavigationContainer();
            flyoutContainer.Init("Rock Paper Scissors", "scissors.png");
            flyoutContainer.AddPage<MainViewModel>("Main");
            flyoutContainer.AddPage<GameViewModel>("Play");
            flyoutContainer.AddPage<SettingsViewModel>("Settings");
            MainPage = flyoutContainer;


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
