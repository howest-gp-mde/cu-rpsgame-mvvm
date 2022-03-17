using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mde.Oef.RPSGame.Domain.Services
{
    public interface IStatisticsService
    {
        Task AddStatistic(GameStatistic statistic);
        Task<IEnumerable<GameStatistic>> GetAll();
        Task<GameStatisticSummary> GetSummary();
    }
}