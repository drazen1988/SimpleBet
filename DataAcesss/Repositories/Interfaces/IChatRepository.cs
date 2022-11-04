using DataAcesss.Data;
using Models.ViewModels;

namespace DataAcesss.Repositories.Interfaces
{
    public interface IChatRepository
    {
        Task<bool> AddPostAsync(ChatPostVM chatPostVM);
        Task<bool> DeletePostAsync(int postId);
        Task<int> UpdatePostAsync(int postId, string title, string message);
        Task<List<ChatPostVM>> GetAllPostsAsync();
        Task<int> LikePostAsync(int postId, string userId);
        Task<int> DislikePostAsync(int postId, string userId);
        Task<bool> AddReplyAsync(ChatReplyVM chatReplyVM);
        Task<bool> DeleteReplyAsync(int replyId);
        Task<int> UpdateReplyAsync(int replyId, string message);
        Task<List<ChatReplyVM>> GetAllRepliesAsync();
    }
}
