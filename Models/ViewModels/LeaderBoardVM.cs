
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels
{
    [NotMapped]
    public class LeaderBoardVM
    {
        [Display(Name = "Pozicija")]
        public int Position { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }

        [Display(Name = "Klan")]
        public string ClanName { get; set; }

        [Display(Name = "Ukupni koeficijent")]
        public decimal TotalCoeficient { get; set; }
    }
}
