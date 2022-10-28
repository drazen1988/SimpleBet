
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Models.ViewModels
{
    public class UsersOverviewVM
    {
        public string Id { get; set; }

        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Ime i prezime")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ClanId { get; set; }

        [Display(Name = "Klan")]
        public string ClanName { get; set; }
    }
}
