using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Oef.RPSGame.Domain.Services
{
    public interface ISettingsService
    {
        Task<Settings> GetSettings();

        Task SaveSettings(Settings settings);

    }
}
