using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IChatRepository
    {
        Task<bool> AddPostAsync(ChatPostVM chatPost);
        Task<bool> DeletePostAsync(int postId);
        Task<int> UpdatePostAsync(ChatPostVM chatPost);
        Task<ChatRoomVM> GetAllPostsAsync();
        Task<ChatPost> GetPostByIdAsync(int postId);
        Task<bool> LikePostAsync(int postId);
        Task<bool> AddReplyAsync(int postId);
        Task<bool> DeleteReplyAsync(int replyId);
        Task<int> UpdateReplyAsync(ChatReplyVM chatReply);
        Task<List<ChatReplyVM>> GetAllRepliesAsync(int postId);
    }
}
