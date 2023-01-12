using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class MyStatsGridVM
    {
        public int MatchId { get; set; }

        [Display(Name = "Domaći")]
        public string HomeTeam { get; set; }

        [Display(Name = "Gosti")]
        public string AwayTeam { get; set; }

        [Display(Name = "Rezultat")]
        public string Result { get; set; }

        [Display(Name = "Tip oklade")]
        public string BetType { get; set; }

        [Display(Name = "Koeficijent")]
        public decimal BetCoeficient { get; set; }

        [Display(Name = "Dobitna oklada")]
        public bool IsWinningBet { get; set; }

        [Display(Name = "Vrijeme utakmice")]
        public DateTime MatchDateTime { get; set; }
    }
}
