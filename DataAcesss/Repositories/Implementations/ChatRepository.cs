using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System.Security.Claims;
using System.Text.RegularExpressions;

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

        public async Task<bool> AddPostAsync(ChatPostVM chatPostVM)
        {
            ChatPost chatPost = _mapper.Map<ChatPostVM, ChatPost>(chatPostVM);
            context.ChatPosts.Add(chatPost);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddReplyAsync(ChatReplyVM chatReplyVM)
        {
            ChatReply chatReply = _mapper.Map<ChatReplyVM, ChatReply>(chatReplyVM);
            context.ChatReplies.Add(chatReply);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            ChatPost existingPost = await context.ChatPosts.FindAsync(postId);

            if (existingPost != null)
            {
                context.ChatPosts.Remove(existingPost);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteReplyAsync(int replyId)
        {
            ChatReply existingReply = await context.ChatReplies.FindAsync(replyId);

            if (existingReply != null)
            {
                context.ChatReplies.Remove(existingReply);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ChatPostVM>> GetAllPostsAsync()
        {
            Task<List<ChatPostVM>> chatPostList = (from post in context.ChatPosts
                                                   join user in context.Users
                                                   on post.AuthorId equals user.Id
                                                   select new ChatPostVM()
                                                   {
                                                       PostId = post.PostId,
                                                       AuthorId = post.AuthorId,
                                                       AuthorName = user.UserName,
                                                       Title = post.Title,
                                                       Message = post.Message,
                                                       PostDateTime = post.PostDateTime,
                                                       TotalLikes = post.TotalLikes.Where(l => l.LikeType.ToLower() == "like").Count(),
                                                       TotalDislikes = post.TotalLikes.Where(l => l.LikeType.ToLower() == "dislike").Count(),
                                                       TotalReplies = post.TotalReplies.Where(r => r.PostId == post.PostId).Count()
                                                   }).OrderByDescending(c => c.PostDateTime).ToListAsync();

            return await chatPostList;
        }

        public async Task<List<ChatReplyVM>> GetAllRepliesAsync()
        {
            Task<List<ChatReplyVM>> chatReplyList = (from reply in context.ChatReplies
                                                     join user in context.Users
                                                     on reply.AuthorId equals user.Id
                                                     select new ChatReplyVM() { ReplyId = reply.ReplyId, AuthorId = reply.AuthorId, AuthorName = user.UserName, Message = reply.Message, PostId = reply.PostId, ReplyDateTime = reply.ReplyDateTime }).OrderBy(c => c.ReplyDateTime).ToListAsync();

            return await chatReplyList;
        }

        public async Task<int> LikePostAsync(int postId, string userId)
        {
            ChatLike existingDislike = await context.ChatLikes.Where(p => p.PostId == postId && p.UserId == userId && p.LikeType.ToLower() == "dislike").FirstOrDefaultAsync();

            // User can't like a post if he already disliked it.
            if (existingDislike == null)
            {
                ChatLike existingLike = await context.ChatLikes.Where(p => p.PostId == postId && p.UserId == userId && p.LikeType.ToLower() == "like").FirstOrDefaultAsync();

                // One user can't like same post twice. Second click will undo post like.
                if (existingLike == null)
                {
                    ChatLike chatLike = new ChatLike();
                    chatLike.UserId = userId;
                    chatLike.PostId = postId;
                    chatLike.LikeType = "Like";
                    context.ChatLikes.Add(chatLike);
                    await context.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    context.ChatLikes.Remove(existingLike);
                    await context.SaveChangesAsync();
                    return -1;
                }
            }

            return 0;
        }

        public async Task<int> DislikePostAsync(int postId, string userId)
        {
            ChatLike existingLike = await context.ChatLikes.Where(p => p.PostId == postId && p.UserId == userId && p.LikeType.ToLower() == "like").FirstOrDefaultAsync();

            // User can't dislike a post if he already liked it.
            if (existingLike == null)
            {
                ChatLike existingDislike = await context.ChatLikes.Where(p => p.PostId == postId && p.UserId == userId && p.LikeType.ToLower() == "dislike").FirstOrDefaultAsync();

                // One user can't dislike same post twice. Second click will undo post dislike.
                if (existingDislike == null)
                {
                    ChatLike chatLike = new ChatLike();
                    chatLike.UserId = userId;
                    chatLike.PostId = postId;
                    chatLike.LikeType = "Dislike";
                    context.ChatLikes.Add(chatLike);
                    await context.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    context.ChatLikes.Remove(existingDislike);
                    await context.SaveChangesAsync();
                    return -1;
                }
            }

            return 0;
        }

        public async Task<int> UpdatePostAsync(int postId, string title, string message)
        {
            ChatPost existingPost = await context.ChatPosts.FindAsync(postId);

            if (existingPost != null)
            {
                existingPost.Title = title;
                existingPost.Message = message;
                context.Update(existingPost);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateReplyAsync(int replyId, string message)
        {
            ChatReply existingReply = await context.ChatReplies.FindAsync(replyId);

            if (existingReply != null)
            {
                existingReply.Message = message;
                context.Update(existingReply);
                return await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
