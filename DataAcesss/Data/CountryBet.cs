using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class CountryBet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CountryBetId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public decimal CountryCoeficient { get; set; }

        public bool IsWinningBet { get; set; }

        [Required]
        public DateTime CountryBetDate { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
