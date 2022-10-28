
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels
{
    [NotMapped]
    public class ClanStatsVM
    {
        [NotMapped]
        public class ClanStatsPercentage
        {
            [Display(Name = "Klan")]
            public string ClanName { get; set; }

            [Display(Name = "Prosječni koeficijent")]
            public decimal AvgCoeficient { get; set; }
        }

        [NotMapped]
        public class ClanStatsAbs
        {
            public string ClanName { get; set; }
            public int WinningBetsCount { get; set; }
        }

        [NotMapped]
        public class ClanUsers
        {
            public string ClanName { get; set; }
            public int UsersCount { get; set; }
            public string Label { get; set; }
        }
    }
    
}
