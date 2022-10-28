using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public  class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

            set { }
        }
        public int ClanId { get; set; }

        [ForeignKey("ClanId")]
        public Clan Clan { get; set; }
    }
}
