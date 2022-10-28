
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class ManageCountriesVM
    {
        public int CountryId { get; set; }

        [Display(Name = "Država")]
        public string CountryName { get; set; }

        [Display(Name = "Koeficijent")]
        public decimal CountryCoeficient { get; set; }

        [Display(Name = "Pobjednik prvenstva")]
        public bool IsWinner { get; set; }
        public string UserId { get; set; }
    }
}
