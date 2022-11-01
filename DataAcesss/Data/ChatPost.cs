using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAcesss.Data
{
    public class ChatPost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PostId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        public List<ChatLike> TotalLikes { get; set; }

        public List<ChatReply> TotalReplies { get; set; }

        [Required]
        public DateTime PostDateTime { get; set; }
    }
}
