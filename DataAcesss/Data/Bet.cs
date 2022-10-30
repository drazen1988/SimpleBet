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

        [Required]
        public string UserId { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public int BetType { get; set; }

        [Required]
        public  decimal BetCoeficient { get; set; }

        public bool IsWinningBet { get; set; }

        [Required]
        public DateTime BetDate { get; set; }

        [ForeignKey("MatchId")]
        public Match Match { get; set; }
    }
}
