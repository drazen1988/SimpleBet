using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class UsersPerClanVM
    {
        public int ClanId { get; set; }

        [Display(Name = "Klan")]
        public string ClanName { get; set; }

        [Display(Name = "Broj korisnika")]
        public int UsersPerClan { get; set; }
    }
}
