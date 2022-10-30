using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class ChatReply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime ReplyDateTime { get; set; }

        [ForeignKey("PostId")]
        public ChatPost ChatPost { get; set; }
    }
}
