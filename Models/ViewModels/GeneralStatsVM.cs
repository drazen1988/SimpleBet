
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels
{
    [NotMapped]
    public class GeneralStatsVM
    {
        [NotMapped]
        public class BestUserStreak
        {
            public BestUserStreak()
            {
                MatchIdList = new List<int>();
            }

            public string UserId { get; set; }

            [Display(Name = "Igrač")]
            public string UserName { get; set; }

            [Display(Name = "Najviše pobjeda u nizu")]
            public int Streak { get; set; }
            public List<int> MatchIdList { get; set; }
        }

        [NotMapped]
        public class MatchList
        {
            [Display(Name = "Utakmica")]
            public string Match { get; set; }
        }

        [NotMapped]
        public class BestUserCoeficient
        {
            public string UserId { get; set; }

            [Display(Name = "Igrač")]
            public string UserName { get; set; }

            [Display(Name = "Najbolji pogođeni koeficijent")]
            public decimal BestCoeficient { get; set; }

            [Display(Name = "Utakmica")]
            public string Match { get; set; }
        }

        [NotMapped]
        public class WinsPerDay
        {
            public DateTime MatchDateTime { get; set; }

            [NotMapped]
            public string MatchDate
            {
                get { return MatchDateTime.ToShortDateString(); }
                set { }
            }

            public int WinnersCount { get; set; }
        }
    }
}
