using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcesss.Data
{
    public class ChatLike
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LikeId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public string LikeType { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime LikeDate { get; set; }

        [ForeignKey("PostId")]
        public ChatPost Post { get; set; }
    }
}
