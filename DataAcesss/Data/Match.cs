using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MatchId { get; set; }
        public string WebId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime MatchDateTime { get; set; }
        public decimal HomeCoeficient { get; set; }
        public decimal DrawCoeficient { get; set; }
        public decimal AwayCoeficient { get; set; }
        public string Result { get; set; }
        public int WinningBetType { get; set; }
        public DateTime MatchDate { get; set; }
        public string UserId { get; set; }
    }
}
