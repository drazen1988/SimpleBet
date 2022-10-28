using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class CountryBet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CountryBetId { get; set; }
        public string UserId { get; set; }
        public int CountryId { get; set; }
        public decimal CountryCoeficient { get; set; }
        public bool IsWinningBet { get; set; }
        public DateTime CountryBetDate { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
