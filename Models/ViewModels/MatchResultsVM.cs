using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class MatchResultsVM
    {
        public int MatchId { get; set; }

        [Display(Name = "Vrijeme utakmice")]
        public DateTime MatchDateTime { get; set; }

        [Display(Name = "Domaći")]
        public string HomeTeam { get; set; }

        [Display(Name = "Gosti")]
        public string AwayTeam { get; set; }

        [Display(Name = "Rezultat")]
        public string Result { get; set; }

        [Display(Name = "Broj pobjednika")]
        public int WinnersCount { get; set; }
    }
}
