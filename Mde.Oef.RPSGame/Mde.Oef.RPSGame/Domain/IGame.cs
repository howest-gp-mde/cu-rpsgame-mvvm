namespace Mde.Oef.RPSGame.Domain
{
    public interface IGame
    {
        GameResult CalculateResult(Hand playerHand, Hand computerHand);
        Hand GetComputerChoice();
        GameStatistic Play(Hand playerChoice);
    }
}