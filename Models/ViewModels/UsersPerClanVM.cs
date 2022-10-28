
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels
{
    [NotMapped]
    public class UsersPerClanVM
    {
        public int ClanId { get; set; }

        [Display(Name = "Klan")]
        public string ClanName { get; set; }

        [Display(Name = "Broj korisnika")]
        public int UsersPerClan { get; set; }
    }
}
