using AutoMapper;
using DataAcesss.Data;
using DataAcesss.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System.Security.Cryptography;

namespace DataAcesss.Repositories.Implementations
{
    public class BetRepository : IBetRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;

        public BetRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        public async Task<Bet> GetBetAsync(int matchId, string userId)
        {
            return await context.Bets.SingleOrDefaultAsync(b => b.MatchId == matchId && b.UserId == userId);
        }

        public async Task<string> SaveBetAsync(BetVM betVM)
        {
            Bet existingBet = await GetBetAsync(betVM.MatchId, betVM.UserId);

            // If bet already exists in DB, then update it.
            if (existingBet != null)
            {
                existingBet.BetType = betVM.BetType;
                existingBet.BetCoeficient = betVM.BetCoeficient;
                context.Bets.Update(existingBet);
                await context.SaveChangesAsync();
                return "update";
            }
            else
            {
                Bet bet = _mapper.Map<BetVM, Bet>(betVM);
                context.Bets.Add(bet);
                await context.SaveChangesAsync();
                return "insert";
            }
        }

        public Task<bool> DeleteBetAsync(int betId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserListVM>> GetWinnerListAsync(int matchId)
        {
            Task<List<UserListVM>> winnerList = (from bet in context.Bets
                                                   join user in context.Users
                                                   on bet.UserId equals user.Id
                                                   where bet.MatchId == matchId && bet.IsWinningBet == true
                                                   orderby user.UserName
                                                   select new UserListVM() { UserId = user.Id, UserName = user.UserName }).ToListAsync();

            return await winnerList;
        }

        public void UpdateWinningBets(int matchId, int betType)
        {
            List<Bet> winningBets = context.Bets.Where(b => b.MatchId == matchId).ToList();

            foreach (Bet bet in winningBets)
            {
                if (bet.BetType == betType)
                {
                    bet.IsWinningBet = true;
                }
                else
                {
                    bet.IsWinningBet = false;
                }
                context.Update(bet);
            }
            context.SaveChanges();
        }

        public async Task<int> GetAllClosedBetsAsync()
        {
            Task<int> closedBetsCount = (from bet in context.Bets
                                join match in context.Matches
                                on bet.MatchId equals match.MatchId
                                where match.MatchDateTime < DateTime.Now
                                select bet.BetId).CountAsync();

            return await closedBetsCount;
        }

        public async Task<int> GetAllWinningBetsAsync()
        {
            return await context.Bets.Where(b => b.IsWinningBet == true).CountAsync();
        }

        public async Task<List<LeaderBoardDetailsVM>> GetAllWinningBetsByUserAsync(string userId)
        {
            var userIdParam = new SqlParameter("@UserId", userId);
            return await context.LeaderBoardDetails.FromSqlRaw("spGetAllWinningBetsByUser @UserId", parameters: new[] { userIdParam }).ToListAsync();
        }

        public async Task<List<UserListVM>> GetUserBetsAsync(int matchId, int betType)
        {
            Task<List<UserListVM>> winnerList = (from bet in context.Bets
                                                 join user in context.Users
                                                 on bet.UserId equals user.Id
                                                 where bet.MatchId == matchId && bet.BetType == betType
                                                 orderby user.UserName
                                                 select new UserListVM() { UserId = user.Id, UserName = user.UserName }).ToListAsync();

            return await winnerList;
        }
    }
}
