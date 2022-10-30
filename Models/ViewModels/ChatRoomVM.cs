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
    }

    public class ChatPostVM
    {
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int TotalLikes { get; set; }
    }

    public class ChatReplyVM
    {
        public int ReplyId { get; set; }
        public string AuthorId { get; set; }
        public string Message { get; set; }
    }
}
