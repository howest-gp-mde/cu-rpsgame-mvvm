using FreshMvvm;
using Mde.Oef.RPSGame.Domain;
using Mde.Oef.RPSGame.Domain.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mde.Oef.RPSGame.ViewModels
{
    public class GameViewModel : FreshBasePageModel
    {
        protected readonly StatisticsService statisticService;
        protected readonly Game game;

        public event EventHandler GameStarted;

        //initialize fields
        public GameViewModel()
        {
            statisticService = new StatisticsService();
            game = new Game();
        }

        ////view model is Pushed to
        //public override void Init(object initData)
        //{

        //}

        ////view model is Popped to
        //public override void ReverseInit(object returnedData)
        //{

        //}

        //de view wordt nu getoond
        
        //protected override void ViewIsAppearing(object sender, EventArgs e)
        //{
            
        //}

        public ICommand PlayCommand => new Command<Hand>(Play);

        private async void Play(Hand playerChoice)
        {
            // keuze van speler verwerken!
            var statistic = game.Play(playerChoice);

            PlayerHand = statistic.PlayerHand;
            ComputerHand = statistic.ComputerHand;
            Result = statistic.Result;

            //update stats
            await statisticService.AddStatistic(statistic);
            var summary = await statisticService.GetSummary();
            Wins = summary.Wins;
            Losses = summary.Losses;
            Draws = summary.Draws;

            // UI triggeren om weergaves/animaties/etc af te spelen
            GameStarted(this, EventArgs.Empty);
        }


        public ICommand PlayAgainCommand => new Command(async () => {

            await CoreMethods.PushPageModel<GameViewModel>(false);
            CoreMethods.RemoveFromNavigation();
        });

        private Hand playerHand;
        public Hand PlayerHand
        {
            get { return playerHand; }
            set { 
                playerHand = value;
                RaisePropertyChanged();
            }
        }


        private Hand computerHand;
        public Hand ComputerHand
        {
            get { return computerHand; }
            set
            {
                computerHand = value;
                RaisePropertyChanged();
            }
        }


        private GameResult gameResult;
        public GameResult Result
        {
            get { return gameResult; }
            set { gameResult = value;
                RaisePropertyChanged();
            }
        }


        private int wins;
        public int Wins {
            get { return wins; }
            set
            {
                wins = value;
                RaisePropertyChanged();
            }
        }

        private int losses;
        public int Losses {
            get { return losses; }
            set
            {
                losses = value;
                RaisePropertyChanged();
            }
        }

        private int draws;
        public int Draws {
            get { return draws; }
            set
            {
                draws = value;
                RaisePropertyChanged();
            }
        }

    }
}
