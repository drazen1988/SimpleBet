using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MatchId { get; set; }

        [Required]
        public string WebId { get; set; }

        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        [Required]
        public DateTime MatchDateTime { get; set; }

        public decimal HomeCoeficient { get; set; }

        public decimal DrawCoeficient { get; set; }

        public decimal AwayCoeficient { get; set; }

        public string Result { get; set; }

        public int WinningBetType { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
