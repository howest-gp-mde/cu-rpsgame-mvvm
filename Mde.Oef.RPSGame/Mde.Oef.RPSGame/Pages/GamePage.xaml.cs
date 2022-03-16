using Mde.Oef.RPSGame.Domain;
using Mde.Oef.RPSGame.Domain.Services;
using Mde.Oef.RPSGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mde.Oef.RPSGame.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        //private Game game;
        private Dictionary<Hand, VisualElement> playerButtons;

        public GamePage()
        {
            InitializeComponent();

            gameLayout.IsVisible = false;

            // initialize buttons dictionary to link a button to each Hand
            // see: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers
            playerButtons = new Dictionary<Hand, VisualElement>
            {
                [Hand.Rock] = playerHandRock,
                [Hand.Paper] = playerHandPaper,
                [Hand.Scissors] = playerHandScissors
            };
        }

        private void ResetUI()
        {
            gameLayout.TranslationY = 0.0D;

            foreach (var button in playerButtons.Values)
            {
                button.TranslationY = -button.HeightRequest * 1.5D;
                button.Opacity = 1.0D;
            }
            advisorLayout.Opacity = 1.0D;
            advisorLayout.IsVisible = true;

            versusLayout.IsVisible = false;
            versusLayout.Opacity = 0.0D;
            playerChoiceImage.Opacity = 0.0D;
            computerChoiceImage.Opacity = 0.0D;

            resultsLayout.IsVisible = false;
            resultsLayout.Opacity = 0.0D;
            lblGameResult.Opacity = 0.0D;
            lblGameResult.Scale = 1.0D;
            lblGameResult.Rotation = 0.0D;

            statisticsLayout.IsVisible = false;
            statisticsLayout.Opacity = 0.0D;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = (GameViewModel) BindingContext;
            viewModel.GameStarted += ViewModel_GameStarted;

            ResetUI();

            gameLayout.IsVisible = true;

            _ = AnimateGameStart();
        }

        private async void ViewModel_GameStarted(object sender, EventArgs e)
        {
            var viewModel = (GameViewModel)BindingContext;

            //set labels
            lblHandAction.Text = "beats";
            if (viewModel.Result == GameResult.PlayerLost)
            {
                lblWinningHand.Text = viewModel.ComputerHand.ToString();
                lblLosingHand.Text = viewModel.PlayerHand.ToString();
                lblGameResult.Text = "YOU LOSE";
                lblGameResult.TextColor = (Color)Application.Current.Resources["ColorFail"];
            }
            else if (viewModel.Result == GameResult.PlayerWin)
            {
                lblWinningHand.Text = viewModel.PlayerHand.ToString();
                lblLosingHand.Text = viewModel.ComputerHand.ToString();
                lblGameResult.Text = "YOU WIN";
                lblGameResult.TextColor = (Color)Application.Current.Resources["ColorSuccess"];
            }
            else
            {
                lblHandAction.Text = "can't beat";
                lblWinningHand.Text = viewModel.PlayerHand.ToString();
                lblLosingHand.Text = viewModel.ComputerHand.ToString();
                lblGameResult.Text = "DRAW";
                lblGameResult.TextColor = (Color)Application.Current.Resources["ColorWarn"];
            }

            //sequential animations
            await AnimatePlayerChoice(viewModel.PlayerHand);
            await AnimateComputerChoice();
            await AnimateGameResult();
            await AnimateStatistics();
        }

        private async Task AnimateGameStart()
        {
            advisorLayout.Opacity = 0.0D;
            advisorLayout.TranslationY = advisorLayout.Y + 50D;

            _ = advisorLayout.FadeTo(1.0D, 500, Easing.Linear);
            _ = advisorLayout.TranslateTo(0, 0, 500, Easing.BounceOut);

            foreach (var button in playerButtons.Values)
            {
                _ = button.TranslateTo(button.X, button.Y, 1000, Easing.BounceOut);
                await Task.Delay(250);
            }

        }

        private async Task AnimatePlayerChoice(Hand chosenHand)
        {
            foreach (var hand in playerButtons.Keys)
            {
                if(hand != chosenHand)
                {
                    var button = playerButtons[hand];
                    _ = button.TranslateTo(button.X, button.Y - button.Height * 1.5D, 250, Easing.SpringIn);
                }
            }

            _ = advisorLayout.FadeTo(0.0D, 200, Easing.SinIn);
            await advisorLayout.TranslateTo(advisorLayout.X, advisorLayout.Y + 50, 200, Easing.SinIn);
            advisorLayout.IsVisible = false;

            _ = playerButtons[chosenHand].FadeTo(0.0f, 500, Easing.SinOut);

            versusLayout.IsVisible = true;
            _ = versusLayout.FadeTo(1.0f, 500, Easing.SinIn);

            await Task.Delay(500);

            playerChoiceImage.TranslationX = -playerChoiceImage.Width;
            _ = playerChoiceImage.FadeTo(1.0f, 500, Easing.SinIn);
            _ = playerChoiceImage.TranslateTo(playerChoiceImage.X, playerChoiceImage.Y, 500, Easing.SpringOut);
        }

        private async Task AnimateComputerChoice()
        {
            await Task.Delay(250);

            computerChoiceImage.TranslationX = computerChoiceImage.Width;
            _ = computerChoiceImage.FadeTo(1.0D, 500, Easing.SinIn);
            _ = computerChoiceImage.TranslateTo(computerChoiceImage.X, computerChoiceImage.Y, 500, Easing.SpringOut);
        }

        private async Task AnimateGameResult()
        {
            _ = gameLayout.TranslateTo(gameLayout.X, -choicesLayout.Height, 500, Easing.SinOut);

            resultsLayout.IsVisible = true;

            await Task.Delay(500);

            _ = resultsLayout.FadeTo(1.0D, 500, Easing.SinIn);

            lblGameResult.Scale = 20.0D;
            lblGameResult.Rotation = 30.0D;

            await Task.Delay(250);
            _ = lblGameResult.RotateTo(5.0D, 500, Easing.Linear);
            _ = lblGameResult.ScaleTo(0.8D, 500, Easing.Linear)
                .ContinueWith((completed) => {
                    _ = lblGameResult.ScaleTo(1.0D, 250, Easing.Linear);
                    _ = lblGameResult.RotateTo(0.0D, 250, Easing.Linear);
                });
            _ = lblGameResult.FadeTo(1.0D, 500, Easing.SinIn);

        }

        private async Task AnimateStatistics()
        {
            statisticsLayout.IsVisible = true;

            await Task.Delay(500);

            _ = statisticsLayout.FadeTo(1.0f, 500, Easing.SinIn);
        }

    }
}