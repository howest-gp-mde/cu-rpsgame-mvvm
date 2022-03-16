using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mde.Oef.RPSGame.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {

        public Command PlayCommand
        {
            get
            {
                return new Command(ExecutePlayCommand);
            }
        }
        private async void ExecutePlayCommand()
        {
            await CoreMethods.PushPageModel<GameViewModel>();
        }

        public Command SettingsCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<SettingsViewModel>();
        });



    }
}
