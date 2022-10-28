
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels
{
    [NotMapped]
    public class MyStatsVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ClanName { get; set; }
        public int? TotalBetCount { get; set; }
        public int? WinningBetCount { get; set; }
        public decimal? BestWinningCoeficient { get; set; }
    }
}
