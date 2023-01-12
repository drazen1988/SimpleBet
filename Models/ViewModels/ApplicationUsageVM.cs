using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class ApplicationUsageVM
    {
        public ApplicationUsageVM()
        {
            LoginTypesList = new List<LoginTypes>();
        }

        public List<LoginTypes> LoginTypesList { get; set; }

        public int ActiveUserCount { get; set; }
        public int ClanCount { get; set; }
        public int WinningBetsCount { get; set; }
        public string OverallAverageCoeficient { get; set; }
        public int ClosedBetsCount { get; set; }
        public int PlayedMatches { get; set; }
        public string BetRatio { get; set; }
        public string WinningBetsRatio { get; set; }


        public class LoginTypes
        {
            [Display(Name = "Vrsta uređaja")]
            public string DeviceType { get; set; }

            [Display(Name = "Broj loginova")]
            public int NumberOfLogins { get; set; }
            public int TotalLogins { get; set; }

            [Display(Name = "Omjer uređaja")]
            public decimal DeviceRatio { get; set; }
        }
    }
}
