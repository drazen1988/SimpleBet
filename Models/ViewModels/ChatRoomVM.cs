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
            ChatPostsFiltered = new List<ChatPostVM>();
            ChatReplies = new List<ChatReplyVM>();
            PostSortDropDownList = new List<PostSortDropDown>();
            AuthorNameUnique = new List<string>();
        }

        public List<ChatPostVM> ChatPosts { get; set; }
        public List<ChatPostVM> ChatPostsFiltered { get; set; }
        public List<ChatReplyVM> ChatReplies { get; set; }
        public string CurrentUserId { get; set; }
        public List<string> AuthorNameUnique { get; set; }
        public List<PostSortDropDown> PostSortDropDownList { get; set; }
        public int SelectedValue { get; set; }

        [Required]
        public string EditPostTitle { get; set; }
        [Required]
        public string EditPostMessage { get; set; }
        [Required]
        public string EditReplyMessage { get; set; }

        public List<PostSortDropDown> InitializeDropDown()
        {
            List<PostSortDropDown> list = new List<PostSortDropDown> {
            new PostSortDropDown(){ SortTypeValue = 1, SortTypeText = "Po datumu" },
            new PostSortDropDown(){ SortTypeValue = 2, SortTypeText = "Po lajkovima" },
            new PostSortDropDown(){ SortTypeValue = 3, SortTypeText = "Po dislajkovima" }
            };

            return list;
        }
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
            get { return AuthorName + ", " + PostDateTime.ToString("g"); }
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
            get { return AuthorName + ", " + ReplyDateTime.ToString("g"); }
            set { }
        }
    }

    public class PostSortDropDown
    {
        public int? SortTypeValue { get; set; }
        public string SortTypeText { get; set; }
    }
}
