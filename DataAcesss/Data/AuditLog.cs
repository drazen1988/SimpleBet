
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAcesss.Data
{
    public class AuditLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LogId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string LogType { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }
    }
}
