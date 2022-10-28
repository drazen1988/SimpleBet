using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcesss.Data
{
    public class EventLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LogId { get; set; }
        public string EventType { get; set; }
        public string TableName { get; set; }
        public string TableField { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string UserId { get; set; }
        public int RowId { get; set; }
        public DateTime LogDate { get; set; }
    }
}
