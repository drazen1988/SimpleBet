
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
        public string UserId { get; set; }

        [Required]
        public string LogType { get; set; }

        [Required]
        public string Message { get; set; }
        public string DeviceType { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }
    }
}
