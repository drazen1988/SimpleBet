using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModels
{
    public class UnactiveUsersVM
    {
        public string Id { get; set; }

        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Ime i prezime")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

            set { }
        }

        public string Email { get; set; }

        [Display(Name = "Klan")]
        public string ClanName { get; set; }

        [Display(Name = "Uspješna prijava")]
        public string HasLoggedIn { get; set; }

        [Display(Name = "Datum zadnje notifikacije")]
        public DateTime? LoginNotificationDate { get; set; }
    }
}
