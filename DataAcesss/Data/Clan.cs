using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAcesss.Data
{
    public class Clan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ClanId { get; set; }

        [Required]
        public string ClanName { get; set; }

        [Required]
        public DateTime ClanDate { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
