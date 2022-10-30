using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Models.ViewModels;

namespace DataAcesss.Repositories.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;

        public ChatRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public Task<bool> AddPostAsync(ChatPostVM chatPost)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddReplyAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReplyAsync(int replyId)
        {
            throw new NotImplementedException();
        }

        public Task<ChatRoomVM> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatReplyVM>> GetAllRepliesAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<ChatPost> GetPostByIdAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LikePostAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePostAsync(ChatPostVM chatPost)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateReplyAsync(ChatReplyVM chatReply)
        {
            throw new NotImplementedException();
        }
    }
}
