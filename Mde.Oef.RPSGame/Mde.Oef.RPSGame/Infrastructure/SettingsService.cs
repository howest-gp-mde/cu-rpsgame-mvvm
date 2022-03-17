using Mde.Oef.RPSGame.Domain;
using Mde.Oef.RPSGame.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Oef.RPSGame.Infrastructure
{
    public class SettingsService : ISettingsService
    {
        private static Settings inMemorySettings = new Settings
        {
            UserName = "",
            Email = "",
            ReceiveWeeklyStats = false
        };

        public Task<Settings> GetSettings()
        {
            return Task.FromResult(inMemorySettings);
        }

        public async Task SaveSettings(Settings settings)
        {
            inMemorySettings = await Task.FromResult(settings);
        }
    }
}
