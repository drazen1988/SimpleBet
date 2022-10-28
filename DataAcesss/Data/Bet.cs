using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class Bet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BetId { get; set; }
        public string UserId { get; set; }
        public int MatchId { get; set; }
        public int BetType { get; set; }
        public  decimal BetCoeficient { get; set; }
        public bool IsWinningBet { get; set; }
        public DateTime BetDate { get; set; }

        [ForeignKey("MatchId")]
        public Match Match { get; set; }
    }
}
