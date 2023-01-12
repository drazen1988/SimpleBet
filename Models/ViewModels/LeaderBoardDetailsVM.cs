using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class LeaderBoardDetailsVM
    {
        [Display(Name = "Utakmica")]
        public string WinningMatch { get; set; }

        [Display(Name = "Koeficijent")]
        public decimal WinningCoeficient { get; set; }
    }
}
