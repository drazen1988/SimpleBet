using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ChatRoomVM
    {
        public ChatRoomVM()
        {
            ChatPosts = new List<ChatPostVM>();
            ChatReplies = new List<ChatReplyVM>();
        }

        public List<ChatPostVM> ChatPosts { get; set; }
        public List<ChatReplyVM> ChatReplies { get; set; }
        public string CurrentUserId { get; set; }
    }

    public class ChatPostVM
    {
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
        public int TotalReplies { get; set; }
        public DateTime PostDateTime { get; set; }
        public string PostFooter
        {
            get { return AuthorName + ", " + PostDateTime.ToString(); }
            set { }
        }
        public bool NewReplyVisible { get; set; }
        public bool EditPostVisible { get; set; }
        public bool AllRepliesVisible { get; set; }
    }

    public class ChatReplyVM
    {
        public int ReplyId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Message { get; set; }
        public int PostId { get; set; }
        public bool EditReplyVisible { get; set; }
        public DateTime ReplyDateTime { get; set; }

        public string ReplyFooter
        {
            get { return AuthorName + ", " + ReplyDateTime.ToString(); }
            set { }
        }
    }
}
