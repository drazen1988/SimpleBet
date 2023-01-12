using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class ClanStatsVM
    {
        public class ClanStatsPercentage
        {
            [Display(Name = "Klan")]
            public string ClanName { get; set; }

            [Display(Name = "Prosječni koeficijent")]
            public decimal AvgCoeficient { get; set; }
        }

        public class ClanStatsAbs
        {
            public string ClanName { get; set; }
            public int WinningBetsCount { get; set; }
            public decimal WinningBetsAvg { get; set; }
        }

        public class ClanUsers
        {
            public string ClanName { get; set; }
            public int UsersCount { get; set; }
            public string Label { get; set; }
        }
    }
}
