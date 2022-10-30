using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }
        public decimal CountryCoeficient { get; set; }
        public bool IsWinner { get; set; }

        [Required]
        public DateTime CountryDate { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
