using FluentValidation;
using Mde.Oef.RPSGame.Domain;
using Mde.Oef.RPSGame.Domain.Services;
using Mde.Oef.RPSGame.Domain.Validators;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mde.Oef.RPSGame.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        //private readonly SettingsService settingsService;
        //private readonly IValidator settingsValidator;
        //private readonly Dictionary<string, Label> errorLabels;
        //private Settings settings;

        public SettingsPage()
        {
            InitializeComponent();


        //    settingsValidator = new SettingsValidator();
        //    settingsService = new SettingsService();

        //    //link property names to error labels
        //    errorLabels = new Dictionary<string, Label>
        //    {
        //        [nameof(Settings.UserName)] = lblUserNameError,
        //        [nameof(Settings.Email)] = lblEmailError,
        //        [nameof(Settings.BirthDate)] = lblBirthDateError,
        //        [nameof(Settings.PrivacyConsent)] = lblConsentError
        //    };
        }

        //protected async override void OnAppearing()
        //{
        //    HideErrorLabels();

        //    settings = await settingsService.GetSettings();
        //    txtUserName.Text = settings.UserName;
        //    txtEmail.Text = settings.Email;
        //    dtpBirthDate.Date = settings.BirthDate ?? DateTime.Today;
        //    chkPrivacyConsent.IsToggled = settings.PrivacyConsent;
        //    chkReceiveStats.IsToggled = settings.ReceiveWeeklyStats;
        //}

        //private void HideErrorLabels()
        //{
        //    foreach (var errorLabel in errorLabels.Values)
        //    {
        //        errorLabel.Text = null;
        //        errorLabel.IsVisible = false;
        //    }
        //}

        //private async void Save_Clicked(object sender, EventArgs e)
        //{
        //    HideErrorLabels();

        //    settings.UserName = txtUserName.Text;
        //    settings.Email = txtEmail.Text;
        //    settings.BirthDate = dtpBirthDate.Date;
        //    settings.PrivacyConsent = chkPrivacyConsent.IsToggled;
        //    settings.ReceiveWeeklyStats = chkReceiveStats.IsToggled;

        //    var validationContext = new ValidationContext<Settings>(settings);
        //    var validationResult = await settingsValidator.ValidateAsync(validationContext);

        //    if (validationResult.IsValid)
        //    {
        //        await settingsService.SaveSettings(settings);
        //        await Navigation.PopAsync(true);
        //    }
        //    else
        //    {
        //        foreach(var validationError in validationResult.Errors)
        //        {
        //            var errorLabel = errorLabels[validationError.PropertyName];
        //            errorLabel.Text = validationError.ErrorMessage;
        //            errorLabel.IsVisible = true;
        //        }
        //    }
        //}
    }
}