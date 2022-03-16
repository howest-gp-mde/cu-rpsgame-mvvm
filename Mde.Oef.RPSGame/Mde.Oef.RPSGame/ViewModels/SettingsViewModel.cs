using FreshMvvm;
using Mde.Oef.RPSGame.Domain;
using Mde.Oef.RPSGame.Domain.Services;
using Mde.Oef.RPSGame.Domain.Validators;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mde.Oef.RPSGame.ViewModels
{
    public class SettingsViewModel : FreshBasePageModel
    {
        protected readonly SettingsService settingsService;
        protected readonly SettingsValidator validator;

        public SettingsViewModel()
        {
            settingsService = new SettingsService();
            validator = new SettingsValidator();
        }

        public override async void Init(object initData)
        {
            var settings = await settingsService.GetSettings();
            UserName = settings.UserName;
            Email = settings.Email;
            BirthDate = settings.BirthDate ?? DateTime.Now;
            Consent = settings.PrivacyConsent;
            WeeklyStats = settings.ReceiveWeeklyStats;
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { 
                userName = value;
                RaisePropertyChanged();
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set {
                email = value;
                RaisePropertyChanged();
            }
        }

        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { 
                birthDate = value;
                RaisePropertyChanged();
            }
        }

        private bool consent;

        public bool Consent
        {
            get { return consent; }
            set { 
                consent = value;
                RaisePropertyChanged();
            }
        }

        private bool weeklyStats;

        public bool WeeklyStats
        {
            get { return weeklyStats; }
            set { 
                weeklyStats = value;
                RaisePropertyChanged();
            }
        }

        #region Error Properties

        private string userNameError;
        public string UserNameError
        {
            get { return userNameError; }
            set { 
                userNameError = value;
                RaisePropertyChanged();
            }
        }


        private string emailError;
        public string EmailError
        {
            get { return emailError; }
            set
            {
                emailError = value;
                RaisePropertyChanged();
            }
        }

        private string birthDateError;
        public string BirthDateError
        {
            get { return birthDateError; }
            set
            {
                birthDateError = value;
                RaisePropertyChanged();
            }
        }

        private string consentError;
        public string ConsentError
        {
            get { return consentError; }
            set
            {
                consentError = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public ICommand SaveCommand => new Command(async () =>
        {
            var settings = new Settings
            {
                BirthDate = BirthDate,
                Email = Email,
                PrivacyConsent = Consent,
                ReceiveWeeklyStats = WeeklyStats,
                UserName = UserName
            };

            var validationResult = validator.Validate(settings);

            //empty the error labels
            UserNameError = default;
            EmailError = default;
            BirthDateError = default;
            ConsentError = default;

            if (validationResult.IsValid)
            {
                await settingsService.SaveSettings(settings);
                //await CoreMethods.DisplayAlert("Jippee", "Settings have been saved", "OK");

                await CoreMethods.PopPageModel();
            }
            else
            {
                foreach (var failure in validationResult.Errors)
                {
                    if (failure.PropertyName == nameof(Settings.UserName)) //"UserName"
                    {
                        UserNameError = failure.ErrorMessage;
                    }
                    else if(failure.PropertyName == nameof(Settings.Email))
                    {
                        EmailError = failure.ErrorMessage;
                    }
                    else if (failure.PropertyName == nameof(Settings.BirthDate))
                    {
                        BirthDateError = failure.ErrorMessage;
                    }
                    else if (failure.PropertyName == nameof(Settings.PrivacyConsent))
                    {
                        ConsentError = failure.ErrorMessage;
                    }
                    else
                    {
                        throw new NotImplementedException($"The property {failure.PropertyName} is not handled in the viewmodel");
                    }
                }
                

            }

        });
    }
}
