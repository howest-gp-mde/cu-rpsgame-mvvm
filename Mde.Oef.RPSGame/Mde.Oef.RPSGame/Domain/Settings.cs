using System;

namespace Mde.Oef.RPSGame.Domain
{
    public struct Settings
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool PrivacyConsent { get; set; }

        public bool ReceiveWeeklyStats { get; set; }
    }
}
