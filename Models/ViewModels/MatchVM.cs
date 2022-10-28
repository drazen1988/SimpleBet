using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class MatchVM
    {
        [Display(Name = "Vrijeme utakmice")]
        public DateTime MatchDateTime { get; set; }

        [Display(Name = "Domaći")]
        public string HomeTeam { get; set; }

        [Display(Name = "Gosti")]
        public string AwayTeam { get; set; }

        [Display(Name = "1")]
        [Range(1.01, Double.MaxValue, ErrorMessage = "Koeficijent mora biti veći od 1")]
        public decimal HomeCoeficient { get; set; }

        [Display(Name = "X")]
        [Range(1.01, Double.MaxValue, ErrorMessage = "Koeficijent mora biti veći od 1")]
        public decimal DrawCoeficient { get; set; }

        [Display(Name = "2")]
        [Range(1.01, Double.MaxValue, ErrorMessage = "Koeficijent mora biti veći od 1")]
        public decimal AwayCoeficient { get; set; }

        [Display(Name = "Rezultat")]
        public string Result { get; set; }

        [Display(Name = "Oklada odigrana")]
        public bool IsBetPlaced { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int WinningBetType { get; set; }
        public string WebId { get; set; }
        public int MatchId { get; set; }
        public string UserId { get; set; }

    }
}
