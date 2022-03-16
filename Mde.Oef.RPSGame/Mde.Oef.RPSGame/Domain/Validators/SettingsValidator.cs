using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mde.Oef.RPSGame.Domain.Validators
{
    public class SettingsValidator : AbstractValidator<Settings>
    {
        public SettingsValidator()
        {
            RuleFor(settings => settings.UserName)
                .MinimumLength(4)
                    .WithMessage("Username must be at least 5 characters long");

            RuleFor(settings => settings.Email)
                .NotEmpty()
                    .WithMessage("Please enter your e-mail address")
                .EmailAddress()
                    .WithMessage("Please enter a valid e-mail address");

            RuleFor(settings => settings.BirthDate)
                .LessThan(DateTime.Today)
                    .WithMessage("Your birthdate should be in the past");

            //Writing a custom validator: https://docs.fluentvalidation.net/en/latest/custom-validators.html
            RuleFor(settings => settings.PrivacyConsent)
                .Custom((hasConsented, context) => {
                    var settings = (Settings)context.InstanceToValidate;
                    if (settings.BirthDate.HasValue)
                    {
                        var isAdult = settings.BirthDate.Value.Date.AddYears(18) <= DateTime.Today;
                        if(!isAdult && hasConsented)
                        {
                            context.AddFailure(nameof(Settings.PrivacyConsent), "You can't consent as a minor");
                        }
                    }
                });
        }
    }
}
