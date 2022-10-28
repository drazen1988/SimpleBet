using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class ErrorLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LogId { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string CallSite { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string StackTrace { get; set; }

        [Required]
        public string InnerException { get; set; }

        [Required]
        public string AdditionalInfo { get; set; }

        [Required]
        public DateTime LogDate { get; set; }
    }
}
